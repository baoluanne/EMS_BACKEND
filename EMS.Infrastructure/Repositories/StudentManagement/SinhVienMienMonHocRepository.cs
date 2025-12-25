using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using EMS.EFCore;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories.StudentManagement
{
    public class SinhVienMienMonHocRepository : AuditRepository<SinhVienMienMonHoc>, ISinhVienMienMonHocRepository
    {
        public SinhVienMienMonHocRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}