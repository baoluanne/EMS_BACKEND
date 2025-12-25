using EMS.Application.Services.KhoaHocServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class KhoaHocController : BaseController<KhoaHoc>
{
    public KhoaHocController(IKhoaHocService khoaHocService) : base(khoaHocService)
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
                || q.TenKhoaHoc.ToLower().Contains(lowercaseKeyword.ToLower())
                || (!string.IsNullOrEmpty(q.Nam) && q.Nam.ToLower().Contains(lowercaseKeyword.ToLower()))
                || (!string.IsNullOrEmpty(q.CachViet) && q.CachViet.ToLower().Contains(lowercaseKeyword.ToLower())
                || (!string.IsNullOrEmpty(q.GhiChu) && q.GhiChu.ToLower().Contains(lowercaseKeyword.ToLower())))
        );

        return result.ToResult();
    }
}