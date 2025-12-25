using Microsoft.EntityFrameworkCore;

namespace EMS.Domain.Interfaces.DataAccess;

public interface IBaseUnitOfWork
{
    Task<int> CommitAsync();
    DbContext GetDbContext();
}
