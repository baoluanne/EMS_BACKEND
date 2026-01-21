using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Persistence.Repositories.KtxManagement
{
    public class KtxCuTruLichSuRepository(DbFactory dbFactory) : AuditRepository<KtxCuTruLichSu>(dbFactory), IKtxCuTruLichSuRepository
    {
    }
}