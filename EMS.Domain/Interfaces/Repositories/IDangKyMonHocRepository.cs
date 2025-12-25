using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Interfaces.Repositories.Base;

namespace EMS.Domain.Interfaces.Repositories
{
    public interface IDangKyMonHocRepository : IAuditRepository<DangKyMonHoc>
    {
        // Add custom methods if needed
        // Task<List<DangKyMonHoc>> GetBySinhVienIdAsync(Guid sinhVienId);
        // Task<List<DangKyMonHoc>> GetByMonHocIdAsync(Guid monHocId);
        // Task<List<DangKyMonHoc>> GetByHocKyAsync(Guid hocKyId, Guid namHocId);
    }
}