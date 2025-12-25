using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using System;
using System.Threading.Tasks;

namespace EMS.Infrastructure.Repositories
{
    public class QuyChe_TinChi_Repository : AuditRepository<QuyChe_TinChi>, IQuyChe_TinChi_Repository
    {
        public QuyChe_TinChi_Repository(DbFactory dbFactory) : base(dbFactory) { }

        public async Task<QuyChe_TinChi?> GetByQuyCheHocVuIdAsync(Guid quyCheHocVuId)
        {
            return await GetFirstAsync(x => x.IdQuyCheHocVu == quyCheHocVuId);
        }
    }
} 