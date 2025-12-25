using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class LoaiKhoanThuRepository(DbFactory dbFactory) : AuditRepository<LoaiKhoanThu>(dbFactory), ILoaiKhoanThuRepository
    {
        // Implement custom methods if defined in interface
    }
}
