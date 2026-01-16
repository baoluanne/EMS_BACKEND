using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories.KtxManagement
{
    public class ToaNhaKtxRepository(DbFactory dbFactory)
        : AuditRepository<KTXToaNha>(dbFactory), IToaNhaKtxRepository
    {
        public async Task<KTXToaNha?> GetStructureAsync(Guid id)
        {
            return await dbFactory.DbContext.Set<KTXToaNha>()
                .Include(x => x.KtxTangs)
                    .ThenInclude(t => t.KtxPhongs)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}