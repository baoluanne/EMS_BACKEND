using EMS.Application.Services.DiaDiemPhongServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMS.Domain.Extensions;
using EMS.Domain.Models;

namespace EMS.API.Controllers;

public class DiaDiemPhongController : BaseController<DiaDiemPhong>
{
    public DiaDiemPhongController(IDiaDiemPhongService diaDiemPhongService) : base(diaDiemPhongService)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q.Include(x => x.CoSoDaoTao));
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
            include: q => q.Include(x => x.CoSoDaoTao),
            filter: q =>
                string.IsNullOrEmpty(lowercaseKeyword)
                || q.TenNhomDDPhong.ToLower().Contains(lowercaseKeyword.ToLower())
                || (q.CoSoDaoTao != null && q.CoSoDaoTao.TenCoSo.ToLower().Contains(lowercaseKeyword.ToLower()))
                || q.MaDDPhong.ToLower().Contains(lowercaseKeyword.ToLower()));
        return result.ToResult();
    }
}