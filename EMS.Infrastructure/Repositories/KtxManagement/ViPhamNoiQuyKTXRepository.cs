using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories.KtxManagement
{
    public class ViPhamNoiQuyKTXRepository(DbFactory dbFactory) : AuditRepository<KtxViPhamNoiQuy>(dbFactory), IViPhamNoiQuyKTXRepository
    {
    }
}