using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class QuyUocCotDiem_NC_Repository(DbFactory dbFactory) : AuditRepository<QuyUocCotDiem_NC>(dbFactory), IQuyUocCotDiem_NC_Repository
    {
    }
} 