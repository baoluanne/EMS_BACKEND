using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class LoaiMonHocRepository(DbFactory dbFactory) : AuditRepository<LoaiMonHoc>(dbFactory), ILoaiMonHocRepository
    {
    }
} 