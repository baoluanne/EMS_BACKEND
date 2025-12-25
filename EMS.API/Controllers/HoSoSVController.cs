using EMS.API.Controllers.Base;
using EMS.Application.Services.HoSoSVServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class HoSoSVController : BaseController<HoSoSV>
{
    private readonly IHoSoSVService _hoSoSVService;

    public HoSoSVController(IHoSoSVService hoSoSVService) : base(hoSoSVService)
    {
        _hoSoSVService = hoSoSVService;
    }

    // Override GetAll to include related entities if needed
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync();
        return result.ToResult();
    }

    // Override GetPaginated with custom filtering
    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] HoSoSVFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            filter: q =>
                (string.IsNullOrEmpty(filter.MaHoSo) ||
                    q.MaHoSo.ToLower().Contains(filter.MaHoSo.ToLower()))
                && (string.IsNullOrEmpty(filter.TenHoSo) ||
                    q.TenHoSo.ToLower().Contains(filter.TenHoSo.ToLower()))
        );
        return result.ToResult();
    }
}

// Filter class for pagination
public class HoSoSVFilter
{
    public string? MaHoSo { get; set; }
    public string? TenHoSo { get; set; }
    // Add other filter properties as needed
}