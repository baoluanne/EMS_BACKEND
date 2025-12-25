using EMS.API.Controllers.Base;
using EMS.Application.Services.PhanChuyenNganhServices;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Enums;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.ClassManagement
{
    public class PhanChuyenNganhController : BaseController<PhanChuyenNganh>
    {
        private readonly IPhanChuyenNganhService _phanChuyenNganhService;

        public PhanChuyenNganhController(IPhanChuyenNganhService phanChuyenNganhService) : base(phanChuyenNganhService)
        {
            _phanChuyenNganhService = phanChuyenNganhService;
        }

        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync(q => q
                .Include(x => x.SinhVien)
                .Include(x => x.ChuyenNganhCu)
                .Include(x => x.ChuyenNganhMoi)
                .Include(x => x.HocKy)
                .Include(x => x.NamHoc)
                .Include(x => x.NguoiDuyet)
            );
            return result.ToResult();
        }

        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] PhanChuyenNganhFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                include: q => q
                    .Include(x => x.SinhVien)
                    .Include(x => x.ChuyenNganhCu)
                    .Include(x => x.ChuyenNganhMoi)
                    .Include(x => x.HocKy)
                    .Include(x => x.NamHoc)
                    .Include(x => x.NguoiDuyet),
                filter: q =>
                    (filter.IdSinhVien == null || q.IdSinhVien == filter.IdSinhVien) ||
                    (filter.IdChuyenNganhCu == null || q.IdChuyenNganhCu == filter.IdChuyenNganhCu) ||
                    (filter.IdChuyenNganhMoi == null || q.IdChuyenNganhMoi == filter.IdChuyenNganhMoi) ||
                    (filter.IdHocKy == null || q.IdHocKy == filter.IdHocKy) ||
                    (filter.IdNamHoc == null || q.IdNamHoc == filter.IdNamHoc) ||
                    (filter.IdNguoiDuyet == null || q.IdNguoiDuyet == filter.IdNguoiDuyet) ||
                    (filter.TrangThai == null || q.TrangThai == filter.TrangThai) ||
                    (filter.LoaiPhanChuyen == null || q.LoaiPhanChuyen == filter.LoaiPhanChuyen) ||
                    (filter.NgayPhanChuyenFrom == null || q.NgayPhanChuyen >= filter.NgayPhanChuyenFrom) ||
                    (filter.NgayPhanChuyenTo == null || q.NgayPhanChuyen <= filter.NgayPhanChuyenTo) ||
                    (filter.NgayDuyetFrom == null || q.NgayDuyet >= filter.NgayDuyetFrom) ||
                    (filter.NgayDuyetTo == null || q.NgayDuyet <= filter.NgayDuyetTo) ||
                    (filter.NgayHieuLucFrom == null || q.NgayHieuLuc >= filter.NgayHieuLucFrom) ||
                    (filter.NgayHieuLucTo == null || q.NgayHieuLuc <= filter.NgayHieuLucTo) ||
                    (string.IsNullOrEmpty(filter.Keyword) || (
                        q.LyDoPhanChuyen.ToLower().Contains(filter.Keyword.ToLower()) ||
                        (q.LyDoTuChoi != null && q.LyDoTuChoi.ToLower().Contains(filter.Keyword.ToLower())) ||
                        (q.GhiChu != null && q.GhiChu.ToLower().Contains(filter.Keyword.ToLower())) ||
                        (q.SinhVien != null && (
                            q.SinhVien.MaSinhVien.ToLower().Contains(filter.Keyword.ToLower()) ||
                            q.SinhVien.Ten.ToLower().Contains(filter.Keyword.ToLower())
                        )) ||
                        (q.ChuyenNganhCu != null && q.ChuyenNganhCu.TenChuyenNganh.ToLower().Contains(filter.Keyword.ToLower())) ||
                        (q.ChuyenNganhMoi != null && q.ChuyenNganhMoi.TenChuyenNganh.ToLower().Contains(filter.Keyword.ToLower()))
                    ))
            );
            return result.ToResult();
        }
    }

    public class PhanChuyenNganhFilter
    {
        public string? Keyword { get; set; }
        
        // Foreign keys
        public Guid? IdSinhVien { get; set; }
        public Guid? IdChuyenNganhCu { get; set; }
        public Guid? IdChuyenNganhMoi { get; set; }
        public Guid? IdHocKy { get; set; }
        public Guid? IdNamHoc { get; set; }
        public Guid? IdNguoiDuyet { get; set; }
        
        // Enums
        public LoaiPhanChuyenNganh? LoaiPhanChuyen { get; set; }
        public TrangThaiPhanChuyenNganh? TrangThai { get; set; }
        
        // Date ranges
        public DateTime? NgayPhanChuyenFrom { get; set; }
        public DateTime? NgayPhanChuyenTo { get; set; }
        public DateTime? NgayDuyetFrom { get; set; }
        public DateTime? NgayDuyetTo { get; set; }
        public DateTime? NgayHieuLucFrom { get; set; }
        public DateTime? NgayHieuLucTo { get; set; }
    }
}