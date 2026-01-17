using DocumentFormat.OpenXml.InkML;
using EMS.API.Controllers.Base;
using EMS.API.Controllers.KtxManagement;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.KtxController
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiuongKtxController : BaseController<KtxGiuong>
    {
        private readonly IGiuongKtxService _service;

        public GiuongKtxController(IGiuongKtxService service) : base(service)
        {
            _service = service;
        }
        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync();
            return result.ToResult();
        }
        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] GiuongFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                filter: q =>
                (string.IsNullOrEmpty(filter.MaGiuong) || q.MaGiuong!.ToLower().Contains(filter.MaGiuong.ToLower()))
                && (string.IsNullOrEmpty(filter.SinhVienId) || q.SinhVienId.ToString() == filter.SinhVienId)
                && (string.IsNullOrEmpty(filter.PhongId) || q.PhongKtxId.ToString() == filter.PhongId)
                && (filter.TrangThai == null || q.TrangThai == int.Parse(filter.TrangThai)),
                include: q => q.Include(x => x.Phong)
                      .Include(x => x.SinhVien)
                      .Include(x => x.Phong!.Tang)
                      .Include(x => x.Phong!.Tang.ToaNha)
            );
            return result.ToResult();
        }
    }
}
public class GiuongFilter
{
    public string? MaGiuong { get; set; }
    public string? SinhVienId { get; set; }
    public string? PhongId { get; set; }
    public string? TrangThai { get; set; }
}
