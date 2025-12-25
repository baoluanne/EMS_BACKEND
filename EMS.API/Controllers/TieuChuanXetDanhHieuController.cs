using System.Globalization;
using EMS.Application.Services.TieuChuanXetDanhHieuServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using EMS.Domain.Common;

namespace EMS.API.Controllers;

public class TieuChuanXetDanhHieuController : BaseController<TieuChuanXetDanhHieu>
{
    public TieuChuanXetDanhHieuController(ITieuChuanXetDanhHieuService tieuChuanXetDanhHieuService) : base(
        tieuChuanXetDanhHieuService)
    {
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowercaseKeyword = keyword?.ToLower();

        var result = await Service.GetPaginatedAsync(
            request,
            filter: q =>
                string.IsNullOrEmpty(lowercaseKeyword)
                || (!string.IsNullOrEmpty(q.GhiChu)
                    && q.GhiChu.ToLower().Contains(lowercaseKeyword))
                || (q.STT != null && q.STT.ToString().Contains(lowercaseKeyword))
                || q.HocLuc10Tu.ToString().Contains(lowercaseKeyword)
                || q.HocLuc10Den.ToString().Contains(lowercaseKeyword)
                || (q.HocLuc4Tu != null && q.HocLuc4Tu.ToString().Contains(lowercaseKeyword))
                || (q.HocLuc4Den != null && q.HocLuc4Den.ToString().Contains(lowercaseKeyword))
                || q.HanhKiemTu.ToString().Contains(lowercaseKeyword)
                || q.HanhKiemDen.ToString().Contains(lowercaseKeyword));

        return result.ToResult();
    }
}