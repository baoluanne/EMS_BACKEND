using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class HanhViViPhamRepository(DbFactory dbFactory) : AuditRepository<HanhViViPham>(dbFactory), IHanhViViPhamRepository
    {
    }
} 