using EMS.Domain.Interfaces.Repositories.Base;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore.Storage;

namespace EMS.Domain.Interfaces.DataAccess;

public interface IUnitOfWork : IBaseUnitOfWork
{
    TRepository GetRepository<TRepository>() where TRepository : IBaseRepository;
    Task<IDbContextTransaction> BeginTransactionAsync();
}
