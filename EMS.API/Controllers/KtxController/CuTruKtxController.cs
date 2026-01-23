using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.KtxManagement
{
    public class CuTruKtxController : BaseController<KtxCutru>
    {
        private readonly ICuTruKtxService _service;

        public CuTruKtxController(ICuTruKtxService service) : base(service)
        {
            _service = service;
        }
        [HttpGet("pagination")]
        public async Task<IActionResult> GetPagination(
    [FromQuery] PaginationRequest request,
    [FromQuery] CuTruFilter filter)
        {
            int? trangThaiInt = null;
            if (!string.IsNullOrEmpty(filter.TrangThai) && int.TryParse(filter.TrangThai, out var tt))
            {
                trangThaiInt = tt;
            }

            var result = await Service.GetPaginatedAsync(
                request,
                filter: q =>
                    (filter.PhongId == null || q.PhongKtxId == filter.PhongId) &&
                    (trangThaiInt == null || (int)q.TrangThai == trangThaiInt)
                    && (filter.SinhVienId == null || q.SinhVienId == filter.SinhVienId)
                    && (string.IsNullOrEmpty(filter.Keyword) ||
                        q.SinhVien.HoDem.Contains(filter.Keyword) ||
                        q.SinhVien.Ten.Contains(filter.Keyword) ||
                        q.SinhVien.MaSinhVien.Contains(filter.Keyword) ||
                        q.PhongKtx.MaPhong.Contains(filter.Keyword))
                    && (filter.TuNgay == null || q.NgayBatDau >= filter.TuNgay)
                    && (filter.DenNgay == null || q.NgayBatDau <= filter.DenNgay),
                include: i => i
                    .Include(x => x.SinhVien)
                    .Include(x => x.PhongKtx)
                    .Include(x => x.GiuongKtx)
                    .Include(x => x.HocKy),
                orderBy: x => x.NgayTao,
                isDescending: true);
            return result.ToResult();
        }

        [HttpGet("history/{sinhVienId:guid}")]
        public async Task<IActionResult> GetHistory(Guid sinhVienId)
        {
            var result = await _service.GetResidencyHistoryAsync(sinhVienId);
            return Ok(new { result = result });
        }
    }

    public class CuTruFilter
    {
        public string? TrangThai { get; set; }
        public Guid? SinhVienId { get; set; }
        public string? Keyword { get; set; }
        public Guid? PhongId { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
    }
}