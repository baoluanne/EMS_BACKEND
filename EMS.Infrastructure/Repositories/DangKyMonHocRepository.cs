using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class DangKyMonHocRepository(DbFactory dbFactory) : AuditRepository<DangKyMonHoc>(dbFactory), IDangKyMonHocRepository
    {
        // Implement custom methods if defined in interface
    }
}