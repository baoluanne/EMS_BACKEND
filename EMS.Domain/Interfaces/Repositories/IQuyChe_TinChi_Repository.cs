using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories.Base;

namespace EMS.Domain.Interfaces.Repositories
{
    public interface IQuyChe_TinChi_Repository : IAuditRepository<QuyChe_TinChi>
    {
        Task<QuyChe_TinChi?> GetByQuyCheHocVuIdAsync(Guid quyCheHocVuId);
    }
} 