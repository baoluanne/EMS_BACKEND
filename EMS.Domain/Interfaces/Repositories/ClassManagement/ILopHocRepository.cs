using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.Base;

namespace EMS.Domain.Interfaces.Repositories.ClassManagement
{
    public interface ILopHocRepository : IAuditRepository<LopHoc>
    {
        // Add custom repository methods here if needed
        // Example:
        // Task<IEnumerable<LopHoc>> GetLopHocByKhoaAsync(Guid idKhoa);
        // Task<IEnumerable<LopHoc>> GetLopHocByKhoaHocAsync(Guid idKhoaHoc);
    }
}