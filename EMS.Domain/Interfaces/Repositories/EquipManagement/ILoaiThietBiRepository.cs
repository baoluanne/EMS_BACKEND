using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Models;

namespace EMS.Domain.Interfaces.Repositories.EquipManagement
{
    public interface ILoaiThietBiRepository : IAuditRepository<TSTBLoaiThietBi>
    {
    }
}
