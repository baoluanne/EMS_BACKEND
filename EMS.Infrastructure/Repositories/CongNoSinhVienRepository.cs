using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class CongNoSinhVienRepository(DbFactory dbFactory)
        : AuditRepository<CongNoSinhVien>(dbFactory), ICongNoSinhVienRepository
    {
    }
}