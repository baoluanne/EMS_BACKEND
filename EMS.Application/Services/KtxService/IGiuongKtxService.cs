using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService;

public interface IGiuongKtxService : IBaseService<GiuongKtx>
{
    Task<Result<GiuongKtxPagingResponse>> GetPaginatedAsync(
        PaginationRequest request,
        string? maGiuong = null,
        string? phongKtxId = null,
        string? trangThai = null);
}