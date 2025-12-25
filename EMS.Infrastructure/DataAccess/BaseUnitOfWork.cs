using EMS.Domain.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.DataAccess;

public abstract class BaseUnitOfWork(DbFactory dbFactory) : IDisposable, IBaseUnitOfWork
{
    private bool _disposed = false;
    protected readonly DbFactory _dbFactory = dbFactory;

    public async Task<int> CommitAsync()
    {
        return await _dbFactory.DbContext.SaveChangesAsync();
    }
    public DbContext GetDbContext() => dbFactory.DbContext;

    public void Dispose()
    {
        if (_disposed || _dbFactory is null) return;
        _disposed = true;
        _dbFactory.Dispose();
        GC.SuppressFinalize(this);
    }
}
