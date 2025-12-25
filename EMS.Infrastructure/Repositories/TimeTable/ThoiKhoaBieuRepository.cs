using EMS.Domain.Entities.TimeTable;
using EMS.Domain.Interfaces.Repositories.TimeTable;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories.TimeTable
{
    public class ThoiKhoaBieuRepository(DbFactory dbFactory) : AuditRepository<ThoiKhoaBieu>(dbFactory), IThoiKhoaBieuRepository
    {
        
    }
}