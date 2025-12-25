using EMS.API.Controllers.Base;
using EMS.Application.Services.LoaiHanhViViPhamServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class LoaiHanhViViPhamController : BaseController<LoaiHanhViViPham>
{
    public LoaiHanhViViPhamController(ILoaiHanhViViPhamService loaiHanhViViPhamService) : base(loaiHanhViViPhamService)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.NhomLoaiHanhVi)
        );
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowercaseKeyword = keyword?.ToLower();

        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q.Include(x => x.NhomLoaiHanhVi),
            filter: q =>
                string.IsNullOrEmpty(lowercaseKeyword)
                || q.MaLoaiHanhVi.ToLower().Contains(lowercaseKeyword.ToLower())
                || (!string.IsNullOrEmpty(q.GhiChu) && q.GhiChu.ToLower().Contains(lowercaseKeyword.ToLower()))
                || q.TenLoaiHanhVi.ToLower().Contains(lowercaseKeyword.ToLower()));
        return result.ToResult();
    }
}