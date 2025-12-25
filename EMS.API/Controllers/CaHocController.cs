using EMS.API.Controllers.Base;
using EMS.Application.Services.CaHocServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class CaHocController : BaseController<CaHoc>
{
    private readonly ICaHocService _caHocService;

    public CaHocController(ICaHocService caHocService) : base(caHocService)
    {
        _caHocService = caHocService;
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
        [FromQuery] CaHocFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            filter: q =>
                (filter.MaCaHoc == null || q.MaCaHoc == filter.MaCaHoc)
                && (string.IsNullOrEmpty(filter.TenCaHoc) || 
                    q.TenCaHoc.ToLower().Contains(filter.TenCaHoc.ToLower()))
                && (string.IsNullOrEmpty(filter.Thu) || 
                    q.Thu != null && q.Thu.ToLower().Contains(filter.Thu.ToLower()))
                && (filter.BuoiHoc == null || q.BuoiHoc == filter.BuoiHoc)
        );
        return result.ToResult();
    }
}

// Filter class for pagination
public class CaHocFilter
{
    public string? MaCaHoc { get; set; }
    public string? TenCaHoc { get; set; }
    public string? Thu { get; set; }
    public Domain.Enums.BuoiHoc? BuoiHoc { get; set; }
    // Add other filter properties as needed
}