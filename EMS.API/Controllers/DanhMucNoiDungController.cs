using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucNoiDungServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class DanhMucNoiDungController : BaseController<DanhMucNoiDung>
{
    private readonly IDanhMucNoiDungService _danhMucNoiDungService;

    public DanhMucNoiDungController(IDanhMucNoiDungService danhMucNoiDungService) : base(danhMucNoiDungService)
    {
        _danhMucNoiDungService = danhMucNoiDungService;
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowerKeyword = keyword?.ToLower();
        var result = await Service.GetPaginatedAsync(
            request,
            filter: q => string.IsNullOrEmpty(lowerKeyword)
                || (q.LoaiNoiDung.ToLower().Contains(lowerKeyword))
                || (q.NoiDung.ToLower().Contains(lowerKeyword))
        );
        return result.ToResult();
    }
}
