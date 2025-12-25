using EMS.API.Controllers.Base;
using EMS.Application.Services.HocKyServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class HocKyController : BaseController<HocKy>
{
    public HocKyController(IHocKyService service) : base(service)
    {
    }
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q.Include(x => x.NamHoc));
        return result.ToResult();
    }
    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword,
        [FromQuery] string? idNamHoc)
    {
        Guid[]? ids = idNamHoc?
        .Split(',', StringSplitOptions.RemoveEmptyEntries)
        .Select(Guid.Parse)
        .ToArray();
        var lowercaseKeyword = keyword?.ToLower();
        var result = await Service.GetPaginatedAsync(
            request,
            filter: q => (ids != null && ids.Contains(q.IdNamHoc))
            && (string.IsNullOrEmpty(lowercaseKeyword)
                || (q.TenDot != null && q.TenDot.ToLower().Contains(lowercaseKeyword))
                || (q.NamHanhChinh != null && q.NamHanhChinh.ToLower().Contains(lowercaseKeyword))
                || (q.TenTiengAnh != null && q.TenTiengAnh.ToLower().Contains(lowercaseKeyword))
                || (q.GhiChu != null && q.GhiChu.ToLower().Contains(lowercaseKeyword))
            )
        );

        return result.ToResult();
    }
}