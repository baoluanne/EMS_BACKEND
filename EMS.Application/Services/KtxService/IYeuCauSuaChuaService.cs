using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService;

public interface IYeuCauSuaChuaService : IBaseService<KtxYeuCauSuaChua>
{
    Task<Result<YeuCauSuaChuaPagingResponse>> GetPaginatedAsync(
        PaginationRequest request,
        Guid? phongKtxId = null,
        Guid? sinhVienId = null,
        string? trangThai = null,
        string? searchTerm = null);
    Task<Result<Guid>> CreateYeuCauAsync(CreateYeuCauSuaChuaDto dto);
    Task<Result<bool>> UpdateTrangThaiAsync(UpdateYeuCauSuaChuaDto dto);
}