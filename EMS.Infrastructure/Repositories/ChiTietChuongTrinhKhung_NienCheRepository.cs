using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class ChiTietChuongTrinhKhung_NienCheRepository(DbFactory dbFactory) : AuditRepository<ChiTietChuongTrinhKhung_NienChe>(dbFactory), IChiTietChuongTrinhKhung_NienCheRepository
    {
    }
} 