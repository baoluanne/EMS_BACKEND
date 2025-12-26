using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService;

public interface ITaiSanKtxService : IBaseService<TaiSanKtx>
{
    Task<Result<TaiSanKtxPagingResponse>> GetPaginatedAsync(
        PaginationRequest request,
        Guid? phongKtxId = null,
        string? tinhTrang = null,
        string? searchTerm = null);

    Task<Result<Guid>> CreateTaiSanAsync(CreateTaiSanKtxDto dto);
    Task<Result<bool>> UpdateTaiSanAsync(UpdateTaiSanKtxDto dto);
}