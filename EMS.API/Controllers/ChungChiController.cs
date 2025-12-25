using EMS.API.Controllers.Base;
using EMS.Application.Services.ChungChiServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class ChungChiController : BaseController<ChungChi>
{
    public ChungChiController(IChungChiService chungChiService) : base(chungChiService)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q.Include(x => x.LoaiChungChi));
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] Guid? idLoaiChungChi)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q.Include(x => x.LoaiChungChi),
            filter: q =>
                idLoaiChungChi == null
                || q.IdLoaiChungChi == idLoaiChungChi
        );
        return result.ToResult();
    }
}