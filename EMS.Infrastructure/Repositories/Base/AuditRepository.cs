using System.Linq.Expressions;
using EMS.Domain.Entities.Base;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories.Base;

public class AuditRepository<T>(DbFactory dbFactory) : Repository<T>(dbFactory), IAuditRepository<T> where T : AuditableEntity
{
    public void Delete(T model)
    {
        model.IsDeleted = true;
        Update(model);
    }

    public async Task<List<T>> ListSoftDeletedAsync()
    {
        var res = await SoftFiltered(true)
            .Where(x => x.IsDeleted)
            .ToListAsync();

        return res;
    }

    public async Task<PaginationResponse<T>> PaginateSoftFilter(
        PaginationRequest pagination,
        bool includeDeleted = false,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? orderBy = null,
        bool isDescending = false)
    {
        return await ToPagedList(SoftFiltered(includeDeleted), pagination, filter, orderBy, isDescending, include);
    }

    protected virtual IQueryable<T> SoftFiltered(bool includeDeleted = false)
    {
        return includeDeleted ? DbSet.IgnoreQueryFilters() : DbSet.IgnoreQueryFilters().Where(x => !x.IsDeleted);
    }

    public static Expression<Func<TEntity, bool>> NotDeleted<TEntity>() where TEntity : AuditableEntity
    {
        return x => !x.IsDeleted;
    }

    public async Task<T?> GetFirstNotDeletedAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null)
    {
        var combinedPredicate = predicate is not null
            ? NotDeleted<T>().And(predicate)
            : NotDeleted<T>();

        return await GetFirstAsync(combinedPredicate, include);
    }
}
