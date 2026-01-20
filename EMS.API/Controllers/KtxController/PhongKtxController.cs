using System.Data.Entity;
using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

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
        var result = await Service.GetPaginatedAsync(
            request,
            filter: q =>
                (string.IsNullOrEmpty(filter.MaPhong)
                    || q.MaPhong!.ToLower().Contains(filter.MaPhong.ToLower()))
                && (string.IsNullOrEmpty(filter.TangId)
                    || q.TangKtxId!.ToString().ToLower().Contains(filter.TangId.ToLower()))
                && (string.IsNullOrEmpty(filter.PhongKtxId)
                    || q.Id!.ToString().ToLower().Contains(filter.PhongKtxId.ToLower()))
                && (filter.Gender == null
                    || (filter.Gender == 0 ? q.LoaiPhong!.ToLower().Contains("nam") : q.LoaiPhong!.ToLower().Contains("nữ"))),
            include: q => q.Include(x => x.Tang).Include(x => x.Tang.ToaNha).Include(x => x.Giuongs));

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