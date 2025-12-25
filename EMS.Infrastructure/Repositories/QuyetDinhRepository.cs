using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class QuyetDinhRepository(DbFactory dbFactory) : AuditRepository<QuyetDinh>(dbFactory), IQuyetDinhRepository
    {
        // Implement custom methods if defined in interface
    }
}