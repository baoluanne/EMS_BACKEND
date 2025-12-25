using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class QuyUocCotDiem_TC_Repository(DbFactory dbFactory) : AuditRepository<QuyUocCotDiem_TC>(dbFactory), IQuyUocCotDiem_TC_Repository
    {
    }
} 