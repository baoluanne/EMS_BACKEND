using EMS.API.Controllers.Base;
using EMS.Application.Services.HinhThucThiServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class HinhThucThiController : BaseController<HinhThucThi>
{
    public HinhThucThiController(IHinhThucThiService hinhThucThiService) : base(hinhThucThiService)
    {
    }
    
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q.Include(x => x.BieuMauDanhSachDuThi));
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
            include: q => q
                .Include(x => x.BieuMauDanhSachDuThi),
            filter: q =>
                string.IsNullOrEmpty(lowercaseKeyword)
                || q.MaHinhThucThi.ToLower().Contains(lowercaseKeyword.ToLower())
                || q.TenHinhThucThi.ToLower().Contains(lowercaseKeyword.ToLower())
                || q.BieuMauDanhSachDuThi != null && q.BieuMauDanhSachDuThi.TenBieuMau.ToLower().Contains(lowercaseKeyword.ToLower())
        );

        return result.ToResult();
    }

}