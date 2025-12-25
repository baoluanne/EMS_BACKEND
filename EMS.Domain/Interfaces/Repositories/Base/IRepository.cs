using System.Linq.Expressions;
using EMS.Domain.Models;

namespace EMS.Domain.Interfaces.Repositories.Base;

public interface IBaseRepository
{
}

public interface IRepository<T> : IBaseRepository where T : class
{
    Task<List<T>> ListAsync(Func<IQueryable<T>, IQueryable<T>>? include = null,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? select = null);

    Task<T?> GetByIdAsync(params object[] keyValues);

    Task<T?> GetFirstAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null);

    T Add(T model);
    void AddRange(IEnumerable<T> models);
    void PermanentlyDelete(T model);
    void PermanentlyDeleteRange(IEnumerable<T> models);
    T Update(T model);

    Task<PaginationResponse<T>> PaginateAsync(
        PaginationRequest pagination,
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? orderBy = null,
        bool isDescending = false,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        Func<IQueryable<T>, IQueryable<T>>? select = null);

    Task<List<T>> GetListAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null);

    Task<PaginationResponse<T>> ToPagedList(
        IQueryable<T> source,
        PaginationRequest pagination,
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? orderBy = null,
        bool isDescending = false,
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        Func<IQueryable<T>, IQueryable<T>>? select = null);
}
