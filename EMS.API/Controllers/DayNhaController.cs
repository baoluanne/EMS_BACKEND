using EMS.Application.Services.DayNhaServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class DayNhaController : BaseController<DayNha>
{
    public DayNhaController(IDayNhaService dayNhaService) : base(dayNhaService)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q.Include(x => x.DiaDiemPhong));
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
            include: q => q.Include(x => x.DiaDiemPhong),
            filter: q =>
                string.IsNullOrEmpty(lowercaseKeyword)
                || q.MaDayNha.ToLower().Contains(lowercaseKeyword.ToLower())
                || q.TenDayNha.ToLower().Contains(lowercaseKeyword.ToLower())
        );

        return result.ToResult();
    }
}