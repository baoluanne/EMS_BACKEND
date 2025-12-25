using EMS.Application.Services.TieuChuanXetHocBongServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class TieuChuanXetHocBongController : BaseController<TieuChuanXetHocBong>
{
    public TieuChuanXetHocBongController(ITieuChuanXetHocBongService tieuChuanXetHocBongService) : base(
        tieuChuanXetHocBongService)
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
                || q.HocBong.ToLower().Contains(lowercaseKeyword.ToLower())
                || (!string.IsNullOrEmpty(q.GhiChu) && q.GhiChu.ToLower().Contains(lowercaseKeyword.ToLower()))
                || (q.STT.ToString().ToLower().Contains(lowercaseKeyword.ToLower()))
                || q.Nhom.ToLower().Contains(lowercaseKeyword.ToLower()));
        return result.ToResult();
    }
}