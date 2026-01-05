using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService;

public interface IChiSoDienNuocService : IBaseService<ChiSoDienNuoc>
{
    Task<Result<ChiSoDienNuocPagingResponse>> GetPaginatedAsync(PaginationRequest request, ChiSoDienNuocFilter filter);
}