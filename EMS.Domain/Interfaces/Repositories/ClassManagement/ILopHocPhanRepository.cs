using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Interfaces.Repositories.Base;

namespace EMS.Domain.Interfaces.Repositories.ClassManagement
{
    public interface ILopHocPhanRepository : IAuditRepository<LopHocPhan>
    {
        // Add custom repository methods for LopHocPhan if needed
        // Example:
        // Task<List<LopHocPhan>> GetByMonHocIdAsync(Guid monHocId);
        // Task<List<LopHocPhan>> GetByGiangVienIdAsync(Guid giangVienId);
    }
}