using EMS.Application.Services.HanhViViPhamServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class HanhViViPhamController : BaseController<HanhViViPham>
{
    public HanhViViPhamController(IHanhViViPhamService hanhViViPhamService) : base(hanhViViPhamService)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.LoaiHanhVi)
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
            include: q => q.Include(x => x.LoaiHanhVi),
            filter: q =>
                string.IsNullOrEmpty(lowercaseKeyword)
                || q.MaHanhVi.ToLower().Contains(lowercaseKeyword.ToLower())
                || (!string.IsNullOrEmpty(q.NoiDung) && q.NoiDung.ToLower().Contains(lowercaseKeyword.ToLower()))
                || q.TenHanhVi.ToLower().Contains(lowercaseKeyword.ToLower()));
        return result.ToResult();
    }
}