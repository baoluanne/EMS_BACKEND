using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class QuyUocCotDiem_MonHocRepository(DbFactory dbFactory) : AuditRepository<QuyUocCotDiem_MonHoc>(dbFactory), IQuyUocCotDiem_MonHocRepository
    {
    }
} 