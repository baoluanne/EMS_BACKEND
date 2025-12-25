using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class QuyChe_NienChe_Repository : AuditRepository<QuyChe_NienChe>, IQuyChe_NienChe_Repository
    {
        public QuyChe_NienChe_Repository(DbFactory dbFactory) : base(dbFactory) { }

        public async Task<QuyChe_NienChe?> GetByQuyCheHocVuIdAsync(Guid quyCheHocVuId)
        {
            return await GetFirstAsync(x => x.IdQuyCheHocVu == quyCheHocVuId);
        }
    }
} 