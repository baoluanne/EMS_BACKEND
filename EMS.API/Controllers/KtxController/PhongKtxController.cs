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
    [FromQuery] PhongFilter PhongFilter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
           filter: q =>
                (string.IsNullOrEmpty(PhongFilter.MaPhong)
                    || q.MaPhong!.ToLower().Contains(PhongFilter.MaPhong.ToLower()))
                && (string.IsNullOrEmpty(PhongFilter.TangId)
                    || q.TangKtxId!.ToString().ToLower().Contains(PhongFilter.TangId.ToLower()))
                && (string.IsNullOrEmpty(PhongFilter.LoaiPhong)
                    || q.LoaiPhong!.ToLower().Contains(PhongFilter.LoaiPhong.ToLower()))
                && (string.IsNullOrEmpty(PhongFilter.PhongKtxId) 
                    || q.Id!.ToString().ToLower().Contains(PhongFilter.PhongKtxId.ToLower())),
            include: q => q.Include(x => x.Tang)
                .Include(x => x.Tang.ToaNha));

        return result.ToResult();
    }
    public class PhongFilter
    {
        public string? MaPhong { get; set; }
        public string? TangId { get; set; }
        public string? PhongKtxId { get; set; }
        public string? LoaiPhong { get; set; }
    }
}