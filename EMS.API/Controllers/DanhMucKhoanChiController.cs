using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucKhoanChiServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class DanhMucKhoanChiController : BaseController<DanhMucKhoanChi>
{
    private readonly IDanhMucKhoanChiService _danhMucKhoanChiService;

    public DanhMucKhoanChiController(IDanhMucKhoanChiService danhMucKhoanChiService) : base(danhMucKhoanChiService)
    {
        _danhMucKhoanChiService = danhMucKhoanChiService;
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
                || (q.TenKhoanChi.ToLower().Contains(lowercaseKeyword))
                || (q.MaKhoanChi.ToLower().Contains(lowercaseKeyword))
                || (q.STT != null && q.STT.ToString()!.ToLower().Contains(lowercaseKeyword.ToLower()))
                || (!string.IsNullOrEmpty(q.GhiChu) &&
                    q.GhiChu.ToLower().Contains(lowercaseKeyword.ToLower()))
        );
        return result.ToResult();
    }
}