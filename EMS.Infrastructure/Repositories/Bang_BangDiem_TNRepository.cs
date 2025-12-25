using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class Bang_BangDiem_TNRepository(DbFactory dbFactory) : AuditRepository<Bang_BangDiem_TN>(dbFactory), IBang_BangDiem_TNRepository
    {
    }
} 