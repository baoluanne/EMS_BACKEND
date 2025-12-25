using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public interface IPhongKtxService : IBaseService<PhongKtx>
    {
        Task<Result<CreatePhongKtxResponseDto>> TaoPhongMoiAsync(CreatePhongKtxRequestDto request);
        Task<Result<PhongKtxPagingResponse>> GetPaginatedAsync(
    PaginationRequest request,
    string? maPhong = null,
    string? toaNhaId = null,
    string? trangThai = null);
    }
}
