using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class ChuyenDoiHocPhanRepository(DbFactory dbFactory) : AuditRepository<ChuyenDoiHocPhan>(dbFactory), IChuyenDoiHocPhanRepository
    {
    }
}