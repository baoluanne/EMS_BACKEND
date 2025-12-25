using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories.StudentManagement
{
    public class SinhVienRepository : AuditRepository<SinhVien>, ISinhVienRepository
    {
        public SinhVienRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<SinhVien?> GetSinhVienByMaSVAsync(string? maSv)
        {
            return await GetFirstAsync(x => x.MaSinhVien == maSv);
        }
    }
}