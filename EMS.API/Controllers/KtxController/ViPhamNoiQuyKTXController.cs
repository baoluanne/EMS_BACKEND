using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.KtxManagement
{
    public class ViPhamNoiQuyKTXController : BaseController<KtxViPhamNoiQuy>
    {
        private readonly IViPhamNoiQuyService _service;

        public ViPhamNoiQuyKTXController(IViPhamNoiQuyService service) : base(service)
        {
            _service = service;
        }
        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] ViPhamNoiQuyFilter filter)
        {
            var result = await _service.GetPaginatedAsync(
                request,
                filter: q =>
                    (string.IsNullOrEmpty(filter.MaBienBan) || q.MaBienBan.ToLower().Contains(filter.MaBienBan.ToLower())) &&
                    (string.IsNullOrEmpty(filter.MaSinhVien) || q.SinhVien!.MaSinhVien.ToLower().Contains(filter.MaSinhVien.ToLower())) &&
                    (string.IsNullOrEmpty(filter.HoTen) || (q.SinhVien!.HoDem + " " + q.SinhVien.Ten).ToLower().Contains(filter.HoTen.ToLower())) &&
                    (filter.TuNgay == null || q.NgayViPham >= filter.TuNgay) &&
                    (filter.DenNgay == null || q.NgayViPham <= filter.DenNgay) &&
                    (string.IsNullOrEmpty(filter.Keyword) ||
                        q.MaBienBan.Contains(filter.Keyword) ||
                        q.SinhVien!.MaSinhVien.Contains(filter.Keyword) ||
                        (q.SinhVien.HoDem + " " + q.SinhVien.Ten).Contains(filter.Keyword)),

                include: i => i.Include(x => x.SinhVien),

                orderBy: x => x.NgayViPham,
                isDescending: true
            );

            return result.ToResult();
        }
        [HttpGet("sinh-vien/{sinhVienId:guid}")]
        public async Task<IActionResult> GetBySinhVien(Guid sinhVienId)
        {
            var result = await _service.GetAllAsync(
                filter: x => x.SinhVienId == sinhVienId,
                include: i => i.Include(x => x.SinhVien)
            );

            return result.ToResult();
        }
    }
    public class ViPhamNoiQuyFilter
    {
        public string? MaBienBan { get; set; }
        public string? MaSinhVien { get; set; }
        public string? HoTen { get; set; }
        public string? Keyword { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
    }
}