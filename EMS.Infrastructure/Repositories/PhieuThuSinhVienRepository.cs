using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class PhieuThuSinhVienRepository(DbFactory dbFactory)
        : AuditRepository<PhieuThuSinhVien>(dbFactory), IPhieuThuSinhVienRepository
    {
    }
}