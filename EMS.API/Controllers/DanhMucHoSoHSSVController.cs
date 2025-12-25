using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucHoSoHSSVServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class DanhMucHoSoHSSVController : BaseController<DanhMucHoSoHSSV>
{
    private readonly IDanhMucHoSoHSSVService _danhMucHoSoHSSVService;

    public DanhMucHoSoHSSVController(IDanhMucHoSoHSSVService danhMucHoSoHSSVService) : base(danhMucHoSoHSSVService)
    {
        _danhMucHoSoHSSVService = danhMucHoSoHSSVService;
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowerKeyword = keyword?.ToLower();

        var result = await Service.GetPaginatedAsync(
            request,
            filter: q => string.IsNullOrEmpty(lowerKeyword)
            || (q.MaHoSo.ToLower().Contains(lowerKeyword))
            || (q.TenHoSo.ToLower().Contains(lowerKeyword))
            || (q.STT != null && q.STT.ToString().ToLower().Contains(lowerKeyword))
            || (!string.IsNullOrEmpty(q.GhiChu) && q.GhiChu.ToLower().Contains(lowerKeyword))
        );
        return result.ToResult();
    }
}