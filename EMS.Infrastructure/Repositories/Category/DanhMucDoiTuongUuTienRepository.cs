using EMS.Domain.Entities.Category;
using EMS.Domain.Interfaces.Repositories.Category;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories.Category
{
    public class DanhMucDoiTuongUuTienRepository(DbFactory dbFactory) : AuditRepository<DanhMucDoiTuongUuTien>(dbFactory), IDanhMucDoiTuongUuTienRepository
    {
    }
}