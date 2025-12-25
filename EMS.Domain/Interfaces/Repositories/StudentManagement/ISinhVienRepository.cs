using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.Repositories.Base;

namespace EMS.Domain.Interfaces.Repositories.StudentManagement
{
    public interface ISinhVienRepository : IAuditRepository<SinhVien>
    {
        Task<SinhVien?> GetSinhVienByMaSVAsync(string? maSv);
        
        
    }
}