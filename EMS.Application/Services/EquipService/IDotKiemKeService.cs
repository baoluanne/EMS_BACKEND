using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.EquipmentManagement;
using LanguageExt.Common;

namespace EMS.Application.Services.EquipService
{
    public interface IDotKiemKeService : IBaseService<TSTBDotKiemKe>
    {
        Task<Result<bool>> AddDevicesFromRoomAsync(Guid dotKiemKeId, Guid phongHocId);
    }
}
