using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class KeHoachDaoTao_TinChiRepository(DbFactory dbFactory) : AuditRepository<KeHoachDaoTao_TinChi>(dbFactory), IKeHoachDaoTao_TinChiRepository
    {
    }
} 