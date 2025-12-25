using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class HinhThucDaoTaoRepository(DbFactory dbFactory) : AuditRepository<HinhThucDaoTao>(dbFactory), IHinhThucDaoTaoRepository
    {
    }
} 