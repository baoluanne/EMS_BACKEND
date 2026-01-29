using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Application.Services.Base;
using EMS.Application.Services.EquipService.Dtos;
using EMS.Domain.Entities.EquipmentManagement;
using LanguageExt.Common;

namespace EMS.Application.Services.EquipService
{
    public interface IThietBiService : IBaseService<TSTBThietBi>
    {
        Task<Result<bool>> PhanVaoPhongAsync(Guid targetId, List<Guid> thietBiIds, bool isKtx);
        Task<Result<List<TSTBThietBi>>> NhapHangLoatAsync(NhapHangLoatDto dto);

    }
}
