using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class LoaiSinhVienRepository(DbFactory dbFactory) : AuditRepository<LoaiSinhVien>(dbFactory), ILoaiSinhVienRepository
    {
        // Implement custom methods if defined in interface
    }
}
