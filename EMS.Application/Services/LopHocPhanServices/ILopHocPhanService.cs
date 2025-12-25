using EMS.Application.Services.Base;
using EMS.Domain.Entities.ClassManagement;

namespace EMS.Application.Services.LopHocPhanServices
{
    public interface ILopHocPhanService : IBaseService<LopHocPhan>
    {
        // Add custom service methods for LopHocPhan if needed
        // Task<List<LopHocPhan>> GetByGiangVienIdAsync(Guid giangVienId);
        // Task<List<LopHocPhan>> GetByHocKyAsync(Guid hocKyId, Guid namHocId);
    }
}