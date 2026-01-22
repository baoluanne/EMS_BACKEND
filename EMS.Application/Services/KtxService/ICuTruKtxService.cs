using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public interface ICuTruKtxService : IBaseService<KtxCutru>
    {
        Task<List<KtxCuTruLichSu>> GetResidencyHistoryAsync(Guid sinhVienId);
        Task<List<KtxCuTruLichSu>> GetResidencyHistoryByDonAsync(Guid donId);
        Task<List<KtxCuTruLichSu>> GetResidencyHistoryByRoomAsync(Guid phongId);
    }
}