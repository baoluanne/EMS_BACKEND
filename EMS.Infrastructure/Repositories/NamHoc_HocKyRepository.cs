using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class NamHoc_HocKyRepository(DbFactory dbFactory) : AuditRepository<NamHoc_HocKy>(dbFactory), INamHoc_HocKyRepository
    {
    }
} 