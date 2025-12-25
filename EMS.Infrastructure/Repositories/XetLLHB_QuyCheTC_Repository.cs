using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class XetLLHB_QuyCheTC_Repository(DbFactory dbFactory) : AuditRepository<XetLLHB_QuyCheTC>(dbFactory), IXetLLHB_QuyCheTC_Repository
    {
    }
} 