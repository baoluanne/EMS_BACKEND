using EMS.API.Controllers.Base;
using EMS.Application.Services.KhoiKienThucServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class KhoiKienThucController : BaseController<KhoiKienThuc>
{
    public KhoiKienThucController(IKhoiKienThucService khoiKienThucService) : base(khoiKienThucService)
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
                || q.TenKhoiKienThuc.ToLower().Contains(lowercaseKeyword.ToLower())
                || (q.GhiChu != null && q.GhiChu.ToLower().Contains(lowercaseKeyword.ToLower()))
                || (q.STT != null && q.STT.ToString().Contains(lowercaseKeyword.ToLower()))
                || q.MaKhoiKienThuc.ToLower().Contains(lowercaseKeyword.ToLower()));
        return result.ToResult();
    }
}