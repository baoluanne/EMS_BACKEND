using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Interfaces.Repositories.ClassManagement;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories.ClassManagement
{
    public class CaHocRepository(DbFactory dbFactory) : AuditRepository<CaHoc>(dbFactory), ICaHocRepository
    {
        // Implement custom methods if defined in interface
        // public async Task<List<CaHoc>> GetBySpecificCriteriaAsync(string criteria)
        // {
        //     return await DbSet.Where(x => x.TenCaHoc.Contains(criteria)).ToListAsync();
        // }
    }
}