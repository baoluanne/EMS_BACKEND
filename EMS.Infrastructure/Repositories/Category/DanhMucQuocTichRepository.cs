using EMS.Domain.Entities.Category;
using EMS.Domain.Interfaces.Repositories.Category;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories.Category
{
    public class DanhMucQuocTichRepository(DbFactory dbFactory) : AuditRepository<DanhMucQuocTich>(dbFactory), IDanhMucQuocTichRepository
    {
    }
}