using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class ChiTietKhungHocKy_TinChiRepository : AuditRepository<ChiTietKhungHocKy_TinChi>, IChiTietKhungHocKy_TinChiRepository
    {
        public ChiTietKhungHocKy_TinChiRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
} 