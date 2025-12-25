using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Infrastructure.DataAccess;

public class UnitOfWork(DbFactory dbFactory, IServiceProvider serviceProvider) : BaseUnitOfWork(dbFactory), IUnitOfWork
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly Dictionary<Type, object> _repositories = [];

    public TRepository GetRepository<TRepository>() where TRepository : IBaseRepository
    {
        var type = typeof(TRepository);

        if (_repositories.TryGetValue(type, out var cachedRepo))
        {
            return (TRepository)cachedRepo;
        }

        var repository = _serviceProvider.GetRequiredService<TRepository>()
            ?? throw new Exception($"Can not get required service: {type}");

        _repositories[type] = repository;
        return repository;
    }
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _dbFactory.DbContext.Database.BeginTransactionAsync();
    }
}
