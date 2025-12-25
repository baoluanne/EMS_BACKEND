using EMS.Application.Services.ApDungQuyCheHocVuServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class ApDungQuyCheHocVuController : BaseController<ApDungQuyCheHocVu>
{
    public ApDungQuyCheHocVuController(IApDungQuyCheHocVuService apDungQuyCheHocVuService) : base(
        apDungQuyCheHocVuService)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.QuyCheNC)
            .ThenInclude(x => x.QuyCheHocVu)
            .Include(x => x.QuyCheTC)
            .ThenInclude(x => x.QuyCheHocVu)
            .Include(x => x.BacDaoTao)
            .Include(x => x.LoaiDaoTao)
            .Include(x => x.KhoaHoc)
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
            include: q => q
                .Include(x => x.QuyCheNC)
                .ThenInclude(x => x.QuyCheHocVu)
                .Include(x => x.QuyCheTC)
                .ThenInclude(x => x.QuyCheHocVu)
                .Include(x => x.BacDaoTao)
                .Include(x => x.LoaiDaoTao)
                .Include(x => x.KhoaHoc)
        );

        return result.ToResult();
    }
}