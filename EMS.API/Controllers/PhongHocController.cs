using EMS.API.Controllers.Base;
using EMS.Application.Services.PhongHocServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using EMS.Domain.Models.Import;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class PhongHocController : BaseController<PhongHoc>
{
    private readonly IPhongHocService _phongHocService;

    public PhongHocController(IPhongHocService phongHocService) : base(phongHocService)
    {
        _phongHocService = phongHocService;
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.LoaiPhong)
            .Include(x => x.TCMonHoc)
            .Include(x => x.DayNha)
        );
        return result.ToResult();
    }

    /// <summary>
    /// Get paginated records
    /// </summary>
    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowercaseKeyword = keyword?.ToLower();

        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q
                .Include(x => x.LoaiPhong)
                .Include(x => x.DayNha)
                .Include(x => x.TCMonHoc),
            filter: q =>
                string.IsNullOrEmpty(lowercaseKeyword)
                || q.TenPhong.ToLower().Contains(lowercaseKeyword.ToLower())
                || q.MaPhong.ToLower().Contains(lowercaseKeyword.ToLower()));
        return result.ToResult();
    }

    [HttpPost("import")]
    public override async Task<IActionResult> Import([FromBody] ImportRequest request)
    {
        if (request?.File == null || request.File.Length == 0)
            return BadRequest("File bị lỗi");
        var result = await _phongHocService.ImportAsync(request.File);
        return Ok(result);
    }
}