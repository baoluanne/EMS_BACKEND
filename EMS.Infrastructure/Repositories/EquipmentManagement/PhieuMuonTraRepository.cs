using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.EquipManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories.EquipmentManagement
{
    public class PhieuMuonTraRepository(DbFactory dbFactory)
       : AuditRepository<TSTBPhieuMuonTra>(dbFactory), IPhieuMuonTraRepository
    {
    }
}
