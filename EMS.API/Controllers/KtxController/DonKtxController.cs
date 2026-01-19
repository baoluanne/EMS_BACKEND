using EMS.API.Controllers.Base;
using EMS.API.Controllers.KtxManagement;
using EMS.Application.Services.KtxService;
using EMS.Application.Services.KtxService.Service;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.KtxController
{
    public class DonKtxController : BaseController<KtxDon>
    {
        private readonly IDonKtxService _donKtxService;

        public DonKtxController(IDonKtxService service) : base(service)
        {
            _donKtxService = service;
        }
        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
                    [FromQuery] PaginationRequest request,
                    [FromQuery] DonKtxFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                filter: q =>
                    (string.IsNullOrEmpty(filter.MaDon) || q.MaDon!.ToLower().Contains(filter.MaDon.ToLower()))
                    && (string.IsNullOrEmpty(filter.LoaiDon) || q.LoaiDon.ToString() == filter.LoaiDon)
                    && (string.IsNullOrEmpty(filter.TrangThai) || q.TrangThai.ToString() == filter.TrangThai)
                    && (filter.IdSinhVien == null || q.IdSinhVien == filter.IdSinhVien)
                    && (filter.IdHocKy == null || q.IdHocKy == filter.IdHocKy)
                    && (filter.TuNgay == null || q.NgayGuiDon >= filter.TuNgay)
                    && (filter.DenNgay == null || q.NgayGuiDon <= filter.DenNgay),
                include: i => i
                    .Include(x => x.SinhVien)
                    .Include(x => x.HocKy)
                    .Include(x => x.GoiDichVu)
                    .Include(x => x.PhongDuocDuyet)
                    .Include(x => x.GiuongDuocDuyet)
                    .Include(x => x.DangKyMoi)
                    .Include(x => x.ChuyenPhong)
                    .Include(x => x.GiaHan)
                    .Include(x => x.RoiKtx),
                orderBy: x => x.NgayGuiDon,
                isDescending: true
            );

            return result.ToResult();
        }


        [HttpPost("{id:guid}/approve")]
        public async Task<IActionResult> Approve(Guid id, [FromQuery] Guid? phongDuyetId, [FromQuery] Guid? giuongDuyetId)
        {
            var result = await _donKtxService.ApproveRequestAsync(id, phongDuyetId, giuongDuyetId);
            return result.ToResult();
        }

        [HttpPost("{id:guid}/reject")]
        public async Task<IActionResult> Reject(Guid id, [FromBody] string ghiChu)
        {
            var result = await _donKtxService.RejectRequestAsync(id, ghiChu);
            return result.ToResult();
        }
    }
    public class DonKtxFilter
    {
        public string? MaDon { get; set; }
        public string? LoaiDon { get; set; }
        public string? TrangThai { get; set; }
        public Guid? IdSinhVien { get; set; }
        public Guid? IdHocKy { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
    }
}