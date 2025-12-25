using EMS.Application.Services.HinhThucXuLyVPQCThiServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class HinhThucXuLyVPQCThiController : BaseController<HinhThucXuLyVPQCThi>
{
    public HinhThucXuLyVPQCThiController(IHinhThucXuLyVPQCThiService hinhThucXuLyVPQCThiService) : base(hinhThucXuLyVPQCThiService)
    {
    }
    
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.MucDo)
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
            include: q => q.Include(x => x.MucDo),
            filter: q =>
                string.IsNullOrEmpty(lowercaseKeyword)
                || q.MaHinhThucXL.ToLower().Contains(lowercaseKeyword.ToLower())
                || q.TenHinhThucXL.ToLower().Contains(lowercaseKeyword.ToLower()));
        return result.ToResult();
    }
} 