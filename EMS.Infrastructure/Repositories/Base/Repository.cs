using System.Linq.Expressions;
using System.Reflection;
using EMS.Domain.Interfaces;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories.Base;

public class Repository<T>(DbFactory dbFactory) : IRepository<T> where T : class
{
    protected DbSet<T> DbSet = dbFactory.DbContext.Set<T>();
    protected bool IsSoftDeletable => typeof(ISoftDeletable).IsAssignableFrom(typeof(T));

    public T Add(T model)
    {
        var entry = DbSet.Add(model);
        return entry.Entity;
    }

    public void AddRange(IEnumerable<T> models)
    {
        DbSet.AddRange(models);
    }

    public void PermanentlyDelete(T model)
    {
        DbSet.Remove(model);
    }

    public void PermanentlyDeleteRange(IEnumerable<T> models)
    {
        DbSet.RemoveRange(models);
    }

    public async Task<T?> GetByIdAsync(params object[] keyValues)
    {
        var entity = await DbSet.FindAsync(keyValues);

        if (entity != null && IsSoftDeletable)
        {
            var softDeletable = entity as ISoftDeletable;
            if (softDeletable?.IsDeleted == true)
            {
                return null;
            }
        }

        return entity;
    }

    public async Task<T?> GetFirstAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null)
    {
        IQueryable<T> query = DbSet;

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<List<T>> ListAsync(Func<IQueryable<T>, IQueryable<T>>? include = null,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? select = null)
    {
        IQueryable<T> query = DbSet;

        if (IsSoftDeletable)
        {
            query = query.Where(x => !((ISoftDeletable)x).IsDeleted);
        }

        if (include is not null)
        {
            query = include(query);
        }

        if (select is not null)
        {
            query = select(query);
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.ToListAsync();
    }

    public async Task<List<T>> GetListAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null)
    {
        IQueryable<T> query = DbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (IsSoftDeletable)
        {
            query = query.Where(x => !((ISoftDeletable)x).IsDeleted);
        }

        if (include is not null)
        {
            query = include(query);
        }

        return await query.ToListAsync();
    }

    public T Update(T model)
    {
        var entry = DbSet.Update(model);
        return entry.Entity;
    }

    public async Task<PaginationResponse<T>> ToPagedList(
        IQueryable<T> source,
        PaginationRequest pagination,
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? orderBy = null,
        bool isDescending = false,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        Func<IQueryable<T>, IQueryable<T>>? select = null)
    {
        if (filter != null)
        {
            source = source.Where(filter);
        }

        if (include != null)
        {
            source = include(source);
        }

        if (IsSoftDeletable)
        {
            source = source.Where(x => !((ISoftDeletable)x).IsDeleted);
        }

        if (orderBy != null)
        {
            source = isDescending ? source.OrderByDescending(orderBy) : source.OrderBy(orderBy);
        }
        else
        {
            source = OrderBy(source, pagination.SortField, pagination.IsDesc);
        }

        if (select != null)
        {
            source = select(source);
        }

        var count = await source.CountAsync();
        var items = await source
            .Skip((pagination.Page - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return new PaginationResponse<T>
        {
            CurrentPage = pagination.Page,
            PageSize = pagination.PageSize,
            TotalCount = count,
            TotalPages = (int)Math.Ceiling(count / (decimal)pagination.PageSize),
            Result = items
        };
    }

    /// <summary>
    /// Dynamically apply OrderBy/OrderByDescending on IQueryable<T>
    /// Supports nested property paths (e.g. "KhoaQuanLy.TenKhoa").
    /// Falls back to a string property (e.g. "Ten...") or "Id" when sorting by complex types.
    /// </summary>
    protected IQueryable<T> OrderBy(IQueryable<T> source, string propertyPath, bool isDescending)
    {
        // Use first property if no sort field provided
        if (string.IsNullOrWhiteSpace(propertyPath))
        {
            var firstProp = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault();
            if (firstProp == null) return source;
            propertyPath = firstProp.Name;
        }

        var parameter = Expression.Parameter(typeof(T), "x");
        Expression propertyAccess = parameter;
        Type currentType = typeof(T);

        // Build expression for nested properties: x => x.Prop1.Prop2...
        foreach (var rawPart in propertyPath.Split('.'))
        {
            var part = currentType.GetProperty(rawPart,
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (part == null) return source; // property not found
            propertyAccess = Expression.Property(propertyAccess, part);
            currentType = part.PropertyType;
        }

        // If final type is a complex class (not scalar/string), fallback to default sort member
        if (currentType != typeof(string) && !currentType.IsValueType)
        {
            var stringProp = currentType.GetProperties()
                                 .FirstOrDefault(p => p.PropertyType == typeof(string) &&
                                                      (p.Name.Equals("Ten", StringComparison.OrdinalIgnoreCase) ||
                                                       p.Name.StartsWith("Ten", StringComparison.OrdinalIgnoreCase)))
                             ?? currentType.GetProperties().FirstOrDefault(p => p.PropertyType == typeof(string));

            if (stringProp != null)
            {
                propertyAccess = Expression.Property(propertyAccess, stringProp);
                currentType = stringProp.PropertyType;
            }
            else
            {
                var idProp = currentType.GetProperty("Id") ??
                             currentType.GetProperty(currentType.Name + "Id",
                                 BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (idProp == null) return source;
                propertyAccess = Expression.Property(propertyAccess, idProp);
                currentType = idProp.PropertyType;
            }
        }

        // Build lambda: x => x.Property
        var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), currentType);
        var lambda = Expression.Lambda(delegateType, propertyAccess, parameter);

        // Call Queryable.OrderBy / OrderByDescending with correct generic types
        var methodName = isDescending ? "OrderByDescending" : "OrderBy";
        var call = Expression.Call(
            typeof(Queryable), methodName,
            [typeof(T), currentType],
            source.Expression, Expression.Quote(lambda));

        // Return IQueryable with ORDER BY applied at database level
        return source.Provider.CreateQuery<T>(call);
    }

    public async Task<PaginationResponse<T>> PaginateAsync(
        PaginationRequest pagination,
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? orderBy = null,
        bool isDescending = false,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        Func<IQueryable<T>, IQueryable<T>>? select = null)
    {
        return await ToPagedList(DbSet, pagination, filter, orderBy, isDescending, include, select);
    }

}