using EMS.Application.Services.Base;
using EMS.Domain.Dtos;
using EMS.Domain.Entities.Views;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.ChuongTrinhKhungMergedServices;

public interface IChuongTrinhKhungMergedService : IBaseService<ChuongTrinhKhungMerged>
{
    Result<PaginationResponse<ChuongTrinhKhungMergedResponseDto>> GetPaginatedMerged(PaginationRequest req, ChuongTrinhKhungFilter filter);
}
