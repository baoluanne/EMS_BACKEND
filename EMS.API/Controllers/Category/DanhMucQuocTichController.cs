using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucQuocTichServices;
using EMS.Domain.Entities.Category;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.Category;

public class DanhMucQuocTichController : BaseController<DanhMucQuocTich>
{
    private readonly IDanhMucQuocTichService _danhMucQuocTichService;

    public DanhMucQuocTichController(IDanhMucQuocTichService danhMucQuocTichService) : base(danhMucQuocTichService)
    {
        _danhMucQuocTichService = danhMucQuocTichService;
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync();
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
            filter: q => string.IsNullOrEmpty(lowercaseKeyword)
                         || (q.MaQuocGia.ToLower().Contains(lowercaseKeyword))
                         || (q.TenQuocGia.ToLower().Contains(lowercaseKeyword)));

        return result.ToResult();
    }
}