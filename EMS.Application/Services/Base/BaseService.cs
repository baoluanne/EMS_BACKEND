using System.Linq.Expressions;
using EMS.Domain.Common;
using EMS.Domain.Entities;
using EMS.Domain.Entities.Base;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Models;
using EMS.Domain.Models.Import;
using FluentValidation;
using LanguageExt.Common;

namespace EMS.Application.Services.Base;

public abstract class BaseService<T> : IBaseService<T> where T : AuditableEntity
{
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly IAuditRepository<T> Repository;

    protected BaseService(IUnitOfWork unitOfWork, IAuditRepository<T> repository)
    {
        UnitOfWork = unitOfWork;
        Repository = repository;
    }

    public virtual async Task<Result<List<T>>> GetAllAsync(
        Func<IQueryable<T>, IQueryable<T>>? include = null,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? select = null)
    {
        try
        {
            var entities = await Repository.ListAsync(include, filter);
            return new Result<List<T>>(entities);
        }
        catch (Exception ex)
        {
            return new Result<List<T>>(ex);
        }
    }

    public virtual async Task<Result<T>> GetByIdAsync(Guid id)
    {
        try
        {
            var entity = await Repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new Result<T>(new NotFoundException($"Entity with ID {id} not found."));
            }

            return new Result<T>(entity);
        }
        catch (Exception ex)
        {
            return new Result<T>(ex);
        }
    }

    public virtual async Task<Result<T>> CreateAsync(T entity)
    {
        try
        {
            Repository.Add(entity);
            await UnitOfWork.CommitAsync();
            return new Result<T>(entity);
        }
        catch (Exception ex)
        {
            return new Result<T>(ex.InnerException ?? ex);
        }
    }

    public async Task<Result<T[]>> CreateManyAsync(T[] entities)
    {
        try
        {
            Repository.AddRange(entities);
            await UnitOfWork.CommitAsync();
            return new Result<T[]>(entities);
        }
        catch (Exception ex)
        {
            return new Result<T[]>(ex.InnerException ?? ex);
        }
    }

    public virtual async Task<Result<T>> UpdateAsync(Guid id, T entity)
    {
        try
        {
            var existingEntity = await Repository.GetByIdAsync(id);
            if (existingEntity == null)
            {
                return new Result<T>(new NotFoundException($"Entity with ID {id} not found."));
            }

            await UpdateEntityProperties(existingEntity, entity);
            Repository.Update(existingEntity);
            await UnitOfWork.CommitAsync();

            return new Result<T>(existingEntity);
        }
        catch (Exception ex)
        {
            return new Result<T>(ex.InnerException ?? ex);
        }
    }

    public virtual async Task<Result<bool>> DeleteAsync(Guid id)
    {
        try
        {
            var entity = await Repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new Result<bool>(new NotFoundException($"Entity with ID {id} not found."));
            }

            Repository.Delete(entity);
            await UnitOfWork.CommitAsync();

            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(ex);
        }
    }

    public virtual async Task<Result<PaginationResponse<T>>> GetPaginatedAsync(PaginationRequest request,
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? orderBy = null,
        bool isDescending = false,
        Func<IQueryable<T>, IQueryable<T>>? include = null)
    {
        try
        {
            var response = await Repository.PaginateAsync(request, filter, orderBy, isDescending, include);
            return new Result<PaginationResponse<T>>(response);
        }
        catch (Exception ex)
        {
            return new Result<PaginationResponse<T>>(ex);
        }
    }

    public virtual async Task<Result<List<T>>> CopyAsync(List<Guid> ids)
    {
        var newEntities = new List<T>();
        try
        {
            foreach (var id in ids)
            {
                var entity = await Repository.GetByIdAsync(id);
                if (entity == null) continue;
                var copy = entity.Clone<T>();
                copy.Id = Guid.NewGuid();
                copy.NgayTao = DateTime.UtcNow;
                copy.NgayCapNhat = DateTime.UtcNow;

                // Special logic for HinhThucXuLyVPQCThi MaHinhThucXL is unique
                if (copy is HinhThucXuLyVPQCThi ht)
                {
                    ht.MaHinhThucXL = $"{ht.MaHinhThucXL} (copy)";
                }


                newEntities.Add(copy);
                Repository.Add(copy);
            }

            await UnitOfWork.CommitAsync();
            return new Result<List<T>>(newEntities);
        }
        catch (Exception ex)
        {
            return new Result<List<T>>(ex);
        }
    }

    public virtual async Task<Result<bool>> DeleteMultipleAsync(List<Guid> ids)
    {
        try
        {
            foreach (var id in ids)
            {
                var entity = await Repository.GetByIdAsync(id);
                if (entity != null)
                {
                    Repository.Delete(entity);
                }
            }

            await UnitOfWork.CommitAsync();
            return new Result<bool>(true);
        }
        catch (Exception ex)
        {
            return new Result<bool>(ex);
        }
    }

    public virtual async Task<ImportResultResponse<TDto>> ImportAsync<TDto>(
        byte[] fileBytes,
        Func<TDto, Task<T>> mapFunc,
        IValidator<TDto>? validator = null,
        Func<List<T>, Task>? processEntities = null)
        where TDto : new()
    {
        try
        {
            var rows = ExcelImportHelper.ParseExcel<TDto>(fileBytes);
            if (rows.Count == 1 && rows[0].RowNumber == 0)
            {
                throw new Exception(rows[0].ParseError);
            }

            var entities = new List<T>();
            var response = new ImportResultResponse<TDto>();

            foreach (var row in rows)
            {
                var rowResult = new ImportRowResponse<TDto> { RowNumber = row.RowNumber, Data = row.Data, };

                try
                {
                    // Check error parse when read data from excel
                    if (!string.IsNullOrEmpty(row.ParseError))
                    {
                        rowResult.Success = false;
                        rowResult.ErrorMessage = row.ParseError;
                        response.Rows.Add(rowResult);
                        response.FailedRecords++;
                        continue;
                    }

                    // FluentValidation check
                    if (validator != null)
                    {
                        var validationResult = await validator.ValidateAsync(row.Data);
                        if (!validationResult.IsValid)
                        {
                            rowResult.Success = false;
                            rowResult.ErrorMessage = string.Join("; ",
                                validationResult.Errors.Select(e => e.ErrorMessage));
                            response.Rows.Add(rowResult);
                            response.FailedRecords++;
                            continue;
                        }
                    }

                    // Map dto -> entity
                    var entity = await mapFunc(row.Data);
                    entities.Add(entity);

                    rowResult.Success = true;
                    response.SuccessRecords++;
                }
                catch (Exception ex)
                {
                    rowResult.Success = false;
                    rowResult.ErrorMessage = ex.Message;
                    response.FailedRecords++;
                }

                response.Rows.Add(rowResult);
            }

            response.TotalRecords = response.Rows.Count;
            if (processEntities != null)
            {
                await processEntities.Invoke(entities);
            }
            else
            {
                if (entities.Any())
                {
                    Repository.AddRange(entities);
                    await UnitOfWork.CommitAsync();
                }
            }

            response.Success = true;
            return response;
        }
        catch (Exception ex)
        {
            // If error when read file, return error for whole file
            return new ImportResultResponse<TDto> { ErrorMessage = ex.Message, };
        }
    }


    protected abstract Task UpdateEntityProperties(T existingEntity, T newEntity);

    public virtual async Task<Result<List<T>>> GetByIdsAsync(List<Guid> ids)
    {
        try
        {
            if (ids == null || ids.Count == 0)
            {
                return new Result<List<T>>(new BadRequestException("Ids cannot be empty"));
            }

            var entities = await Repository.ListAsync(filter: x => ids.Contains(x.Id));

            if (entities == null || entities.Count == 0)
            {
                return new Result<List<T>>(new NotFoundException("Not Found"));
            }

            return new Result<List<T>>(entities);
        }
        catch (Exception ex)
        {
            return new Result<List<T>>(ex);
        }
    }
}