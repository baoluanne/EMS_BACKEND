using EMS.Application.Services.LoaiChungChiServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class LoaiChungChiController : BaseController<LoaiChungChi>
{
    public LoaiChungChiController(ILoaiChungChiService loaiChungChiService) : base(loaiChungChiService)
    {
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowercaseKeyword = keyword?.ToLower();

        var result = await Service.GetPaginatedAsync(
            request,
            filter: q =>
                string.IsNullOrEmpty(lowercaseKeyword)
                || q.TenLoaiChungChi.ToLower().Contains(lowercaseKeyword.ToLower())
                || q.MaLoaiChungChi.ToLower().Contains(lowercaseKeyword.ToLower()));
        return result.ToResult();
    }
}