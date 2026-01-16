using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Models;

namespace EMS.Domain.Interfaces.Repositories.KtxManagement
{
    public interface IToaNhaKtxRepository : IAuditRepository<KTXToaNha>
    {
        Task<KTXToaNha?> GetStructureAsync(Guid id);
    }
}
