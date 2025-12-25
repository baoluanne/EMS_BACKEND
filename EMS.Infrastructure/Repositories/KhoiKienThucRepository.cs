using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class KhoiKienThucRepository(DbFactory dbFactory) : AuditRepository<KhoiKienThuc>(dbFactory), IKhoiKienThucRepository
    {
    }
} 