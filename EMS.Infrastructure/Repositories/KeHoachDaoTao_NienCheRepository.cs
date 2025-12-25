using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class KeHoachDaoTao_NienCheRepository(DbFactory dbFactory) : AuditRepository<KeHoachDaoTao_NienChe>(dbFactory), IKeHoachDaoTao_NienCheRepository
    {
    }
} 