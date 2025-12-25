using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucHocBongServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class DanhMucHocBongController : BaseController<DanhMucHocBong>
{
    public DanhMucHocBongController(IDanhMucHocBongService danhMucHocBongService) : base(danhMucHocBongService)
    {
    }

    /// <summary>
    /// Get paginated records
    /// </summary>
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
                || q.TenDanhMuc.ToLower().Contains(lowercaseKeyword.ToLower())
                || q.MaDanhMuc.ToLower().Contains(lowercaseKeyword.ToLower()));
        return result.ToResult();
    }
}