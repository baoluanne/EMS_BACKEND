using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories
{
    public class ChinhSachMienGiamRepository(DbFactory dbFactory)
        : AuditRepository<ChinhSachMienGiam>(dbFactory), IChinhSachMienGiamRepository
    {
    }
}
