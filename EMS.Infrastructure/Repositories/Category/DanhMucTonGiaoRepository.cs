using EMS.Domain.Entities.Category;
using EMS.Domain.Interfaces.Repositories.Category;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories.Category
{
    public class DanhMucTonGiaoRepository(DbFactory dbFactory) : AuditRepository<DanhMucTonGiao>(dbFactory), IDanhMucTonGiaoRepository
    {
    }
}