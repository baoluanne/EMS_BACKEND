using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucBieuMauServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class DanhMucBieuMauController : BaseController<DanhMucBieuMau>
{
    private readonly IDanhMucBieuMauService _service;

    public DanhMucBieuMauController(IDanhMucBieuMauService service) : base(service)
    {
        _service = service;
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.KhoaQuanLy)
        );
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword,
        [FromQuery] Guid? idKhoaQuanLy)
    {
        var lowercaseKeyword = keyword?.ToLower();

        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q.Include(x => x.KhoaQuanLy),
            filter: q =>
                (idKhoaQuanLy == null || q.IdKhoaQuanLy == idKhoaQuanLy)
                && (string.IsNullOrEmpty(lowercaseKeyword)
                    || q.MaBieuMau.ToLower().Contains(lowercaseKeyword)
                    || q.TenBieuMau.ToLower().Contains(lowercaseKeyword)
                    || (!string.IsNullOrEmpty(q.GhiChu) && q.GhiChu.ToLower().Contains(lowercaseKeyword))
                )
        );
        return result.ToResult();
    }
}


