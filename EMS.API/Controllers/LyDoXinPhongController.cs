using EMS.Application.Services.LyDoXinPhongServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class LyDoXinPhongController : BaseController<LyDoXinPhong>
{
    public LyDoXinPhongController(ILyDoXinPhongService lyDoXinPhongService) : base(lyDoXinPhongService)
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
                || q.MaLoaiXinPhong.ToLower().Contains(lowercaseKeyword.ToLower())
                || q.TenLoaiXinPhong.ToLower().Contains(lowercaseKeyword.ToLower()));
        return result.ToResult();
    }
} 