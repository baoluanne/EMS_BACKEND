using EMS.API.Controllers.Base;
using EMS.Application.Services.LoaiSinhVienServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class LoaiSinhVienController : BaseController<LoaiSinhVien>
{
    private readonly ILoaiSinhVienService _loaiSinhVienService;

    public LoaiSinhVienController(ILoaiSinhVienService loaiSinhVienService) : base(loaiSinhVienService)
    {
        _loaiSinhVienService = loaiSinhVienService;
    }

    // Override GetAll to include related entities when properties are confirmed
    // public override async Task<IActionResult> GetAll()
    // {
    //     var result = await Service.GetAllAsync(q => q
    //         .Include(x => x.RelatedEntity)
    //     );
    //     return result.ToResult();
    // }

    // Override GetPaginated with custom filtering when properties are confirmed
    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] LoaiSinhVienFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            filter: q => true // Add filtering logic when properties are confirmed
        );
        return result.ToResult();
    }
}

// Filter class for pagination
public class LoaiSinhVienFilter
{
    // Add filter properties when entity properties are confirmed
}
