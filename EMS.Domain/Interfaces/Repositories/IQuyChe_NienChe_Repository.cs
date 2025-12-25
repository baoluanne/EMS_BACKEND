using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories.Base;

namespace EMS.Domain.Interfaces.Repositories
{
    public interface IQuyChe_NienChe_Repository : IAuditRepository<QuyChe_NienChe>
    {
        Task<QuyChe_NienChe?> GetByQuyCheHocVuIdAsync(Guid quyCheHocVuId);
    }
} 