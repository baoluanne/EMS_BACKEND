using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.EquipmentManagement;
using LanguageExt.Common;

namespace EMS.Application.Services.EquipService
{
    public interface IThietBiService : IBaseService<TSTBThietBi>
    {
        Task<Result<bool>> PhanVaoPhongAsync(Guid targetId, List<Guid> thietBiIds, bool isKtx);
        new Task<Result<TSTBThietBi[]>> CreateManyAsync(TSTBThietBi[] entities);
    }
}