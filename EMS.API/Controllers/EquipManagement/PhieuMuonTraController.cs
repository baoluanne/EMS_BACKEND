using EMS.API.Controllers.Base;
using EMS.Application.Services.EquipService;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Enums.EquipmentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.EquipManagement
{
    public class PhieuMuonTraController : BaseController<TSTBPhieuMuonTra>
    {
        public PhieuMuonTraController(IPhieuMuonTraService service) : base(service)
        {
        }

        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] PhieuMuonTraFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                filter: q =>
                    (string.IsNullOrEmpty(filter.MaPhieu) || q.MaPhieu.ToLower().Contains(filter.MaPhieu.ToLower())) &&
                    (!filter.LoaiDoiTuong.HasValue || q.LoaiDoiTuong == filter.LoaiDoiTuong) &&
                    (!filter.TrangThai.HasValue || q.TrangThai == filter.TrangThai) &&
                    (!filter.SinhVienId.HasValue || q.SinhVienId == filter.SinhVienId) &&
                    (!filter.GiangVienId.HasValue || q.GiangVienId == filter.GiangVienId) &&
                    (!filter.TuNgay.HasValue || q.NgayMuon >= filter.TuNgay) &&
                    (!filter.DenNgay.HasValue || q.NgayMuon <= filter.DenNgay),
                include: i => i
                    .Include(x => x.SinhVien) //
                    .Include(x => x.GiangVien) //
                    .Include(x => x.NguoiDuyet) //
                    .Include(x => x.NguoiTra) //
                    .Include(x => x.ChiTietPhieuMuons) //
                        .ThenInclude(ct => ct.ThietBi),
                orderBy: x => x.NgayMuon,
                isDescending: true);

            return result.ToResult();
        }

        public class PhieuMuonTraFilter
        {
            public string? MaPhieu { get; set; }
            public LoaiDoiTuongMuonEnum? LoaiDoiTuong { get; set; } //
            public TrangThaiPhieuMuonEnum? TrangThai { get; set; } //
            public Guid? SinhVienId { get; set; }
            public Guid? GiangVienId { get; set; }
            public DateTime? TuNgay { get; set; }
            public DateTime? DenNgay { get; set; }
        }
    }
}