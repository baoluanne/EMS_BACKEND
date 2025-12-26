using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService;

public interface IHoaDonKtxService : IBaseService<HoaDonKtx>
{
    Task<Result<HoaDonKtxPagingResponse>> GetPaginatedAsync(
        PaginationRequest request,
        Guid? phongKtxId = null,
        int? thang = null,
        int? nam = null,
        string? trangThai = null);

    Task<Result<Guid>> CreateHoaDonAsync(CreateHoaDonKtxDto dto);
    Task<Result<bool>> ThanhToanHoaDonAsync(Guid id, string? ghiChu = null);
}