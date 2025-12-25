using EMS.Application.Services.Base;
using EMS.Domain.Entities.ClassManagement;

namespace EMS.Application.Services.LopHocServices
{
    public interface ILopHocService : IBaseService<LopHoc>
    {
        // Add custom service methods here if needed
        // Example:
        // Task<IEnumerable<LopHoc>> GetLopHocByKhoaAsync(Guid idKhoa);
        // Task<IEnumerable<LopHoc>> GetLopHocByKhoaHocAsync(Guid idKhoaHoc);
    }
}