using System.Linq.Expressions;
using EMS.Domain.Entities.Base;
using EMS.Domain.Models;
using EMS.Domain.Models.Import;
using FluentValidation;
using LanguageExt.Common;

namespace EMS.Application.Services.Base
{
    public interface IBaseService<T> where T : AuditableEntity
    {
        Task<Result<List<T>>> GetAllAsync(
            Func<IQueryable<T>, IQueryable<T>>? include = null,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IQueryable<T>>? select = null);

        Task<Result<T>> GetByIdAsync(Guid id);
        Task<Result<T>> CreateAsync(T entity);
        Task<Result<T[]>> CreateManyAsync(T[] entity);
        Task<Result<T>> UpdateAsync(Guid id, T entity);
        Task<Result<bool>> DeleteAsync(Guid id);

        Task<Result<PaginationResponse<T>>> GetPaginatedAsync(PaginationRequest request,
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, object>>? orderBy = null,
            bool isDescending = false,
            Func<IQueryable<T>, IQueryable<T>>? include = null);

        Task<Result<List<T>>> CopyAsync(List<Guid> ids);
        Task<Result<bool>> DeleteMultipleAsync(List<Guid> ids);

        Task<ImportResultResponse<TDto>> ImportAsync<TDto>(
            byte[] fileBytes,
            Func<TDto, Task<T>> mapFunc,
            IValidator<TDto>? validator = null,
            Func<List<T>, Task>? processEntities = null) where TDto : new();

        Task<Result<List<T>>> GetByIdsAsync(List<Guid> ids);
    }
}