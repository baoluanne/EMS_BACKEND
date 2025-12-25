using EMS.Application.Services.Base;
using EMS.Domain.Entities.ClassManagement;

namespace EMS.Application.Services.DangKyMonHocServices
{
    public interface IDangKyMonHocService : IBaseService<DangKyMonHoc>
    {
        // Add custom service methods if needed
        // Task<List<DangKyMonHoc>> GetBySinhVienIdAsync(Guid sinhVienId);
        // Task<List<DangKyMonHoc>> GetByMonHocIdAsync(Guid monHocId);
        // Task<List<DangKyMonHoc>> GetByHocKyAsync(Guid hocKyId, Guid namHocId);
    }
}