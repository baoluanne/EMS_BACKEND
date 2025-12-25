using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using EMS.EFCore;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories.StudentManagement
{
    public class SinhVienNganh2Repository : AuditRepository<SinhVienNganh2>, ISinhVienNganh2Repository
    {
        public SinhVienNganh2Repository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}