using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class LoaiChucVuRepository(DbFactory dbFactory) : AuditRepository<LoaiChucVu>(dbFactory), ILoaiChucVuRepository
    {
        // Implement custom methods if defined in interface
    }
}
