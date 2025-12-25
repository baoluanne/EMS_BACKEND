using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories.StudentManagement
{
    public class DanhSachSinhVienDuocInTheRepository : AuditRepository<DanhSachSinhVienDuocInThe>, IDanhSachSinhVienDuocInTheRepository
    {
        public DanhSachSinhVienDuocInTheRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}