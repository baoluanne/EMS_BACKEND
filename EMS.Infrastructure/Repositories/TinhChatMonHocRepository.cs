using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class TinhChatMonHocRepository(DbFactory dbFactory) : AuditRepository<TinhChatMonHoc>(dbFactory), ITinhChatMonHocRepository
    {
    }
} 