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
                    (string.IsNullOrEmpty(filter.Keyword) ||
                        q.SinhVien.HoDem.ToLower().Contains(filter.Keyword.ToLower()) ||
                        q.SinhVien.Ten.ToLower().Contains(filter.Keyword.ToLower()) ||
                        q.SinhVien.MaSinhVien.ToLower().ToLower().Contains(filter.Keyword.ToLower()) ||
                        q.PhongKtx.MaPhong.ToLower().Contains(filter.Keyword.ToLower()) ||
                        q.GiuongKtx.MaGiuong.ToLower().Contains(filter.Keyword.ToLower())) &&
                    (string.IsNullOrEmpty(filter.MaSinhVien) ||
                        q.SinhVien.MaSinhVien.ToLower().Contains(filter.MaSinhVien.ToLower())) &&
                    (string.IsNullOrEmpty(filter.HoTen) ||
                        q.SinhVien.HoDem.ToLower().Contains(filter.HoTen.ToLower()) ||
                        q.SinhVien.Ten.ToLower().Contains(filter.HoTen.ToLower())) &&
                    (string.IsNullOrEmpty(filter.MaPhong) ||
                        q.PhongKtx.MaPhong.ToLower().Contains(filter.MaPhong.ToLower())) &&
                    (string.IsNullOrEmpty(filter.MaGiuong) ||
                        q.GiuongKtx.MaGiuong.ToLower().Contains(filter.MaGiuong.ToLower())) &&
                    (trangThaiInt == null || (int)q.TrangThai == trangThaiInt) &&
                    (filter.SinhVienId == null || q.SinhVienId == filter.SinhVienId) &&
                    (filter.TuNgay == null || q.NgayBatDau >= filter.TuNgay) &&
                    (filter.DenNgay == null || q.NgayBatDau <= filter.DenNgay)&&
                    (filter.ViPhamKtx == null ||(filter.ViPhamKtx == 1? q.TongDiemViPham > 0: q.TongDiemViPham >= filter.ViPhamKtx))&&
                    (filter.ViPhamKtx == null || q.TongDiemViPham >= filter.ViPhamKtx ),
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
        public class CuTruFilter
        {
            public string? TrangThai { get; set; }
            public Guid? SinhVienId { get; set; }
            public string? Keyword { get; set; }
            public string? MaPhong { get; set; }  // Thêm dòng này
            public string? MaSinhVien { get; set; }  // Thêm dòng này
            public string? HoTen { get; set; }  // Thêm dòng này
            public string? MaGiuong { get; set; }  // Thêm dòng này
            public DateTime? TuNgay { get; set; }
            public DateTime? DenNgay { get; set; }
            public int? ViPhamKtx { get; set; }
        }
    }
}