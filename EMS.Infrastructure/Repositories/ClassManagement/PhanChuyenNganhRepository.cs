using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Interfaces.Repositories.ClassManagement;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories.ClassManagement
{
    public class PhanChuyenNganhRepository : AuditRepository<PhanChuyenNganh>, IPhanChuyenNganhRepository
    {
        public PhanChuyenNganhRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}