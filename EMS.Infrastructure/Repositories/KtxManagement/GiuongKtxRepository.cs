using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories.KtxManagement
{
    public class GiuongKtxRepository(DbFactory dbFactory)
        : AuditRepository<KtxGiuong>(dbFactory), IGiuongKtxRepository
    {
    }
}