using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories.Base;

namespace EMS.Domain.Interfaces.Repositories.ClassManagement
{
    public interface ICaHocRepository : IAuditRepository<CaHoc>
    {
        // Add custom methods if needed
        // Task<List<CaHoc>> GetBySpecificCriteriaAsync(string criteria);
    }
}