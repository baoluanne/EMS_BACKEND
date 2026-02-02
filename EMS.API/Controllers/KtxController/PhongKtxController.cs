using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.KtxManagement;

[ApiController]
[Route("api/[controller]")]
public class PhongKtxController(IPhongKtxService service) : BaseController<KtxPhong>(service)
{
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync();
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] PhongFilter filter)
    {
        Guid? tangGuid = null;
        if (!string.IsNullOrEmpty(filter.TangId) && Guid.TryParse(filter.TangId, out var tId))
            tangGuid = tId;

        Guid? phongGuid = null;
        if (!string.IsNullOrEmpty(filter.PhongKtxId) && Guid.TryParse(filter.PhongKtxId, out var pId))
            phongGuid = pId;

        var result = await Service.GetPaginatedAsync(
            request,
            filter: q =>
                (string.IsNullOrEmpty(filter.MaPhong) || q.MaPhong!.ToLower().Contains(filter.MaPhong.ToLower()))
                && (tangGuid == null || q.TangKtxId == tangGuid)
                && (phongGuid == null || q.Id == phongGuid)
                && (filter.Gender == null
                    || (filter.Gender == 0 ? q.LoaiPhong!.ToLower().Contains("nam") : q.LoaiPhong!.ToLower().Contains("nữ"))),
            orderBy: q => q.MaPhong!,
            include: q => q.Include(x => x.Tang)
                .Include(x => x.Tang.ToaNha)
                .Include(x => x.Giuongs)
                .ThenInclude(g => g.SinhVien));

        return result.ToResult();
    }

    public class PhongFilter
    {
        public string? MaPhong { get; set; }
        public string? TangId { get; set; }
        public string? PhongKtxId { get; set; }
        public int? Gender { get; set; }
    }
}