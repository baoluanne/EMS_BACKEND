using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class ThongTinChung_QuyCheTC_Repository(DbFactory dbFactory) : AuditRepository<ThongTinChung_QuyCheTC>(dbFactory), IThongTinChung_QuyCheTC_Repository
    {
    }
} 