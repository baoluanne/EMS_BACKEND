using EMS.API.Controllers.Base;
using EMS.Application.Services.ChuyenTruongServices;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMS.Domain.Enums;

namespace EMS.API.Controllers.StudentManagement
{
    public class ChuyenTruongController : BaseController<ChuyenTruong>
    {
        private readonly IChuyenTruongService _chuyenTruongService;

        public ChuyenTruongController(IChuyenTruongService chuyenTruongService) : base(chuyenTruongService)
        {
            _chuyenTruongService = chuyenTruongService;
        }

        // Override GetAll to include related entities
        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync(q => q
                .Include(x => x.CoSo)
                .Include(x => x.KhoaHoc)
                .Include(x => x.BacDaoTao)
                .Include(x => x.LoaiDaoTao)
                .Include(x => x.NganhHoc)
                .Include(x => x.SinhVien)
                .Include(x => x.ChuyenNganh)
                .Include(x => x.LopHoc)
            );
            return result.ToResult();
        }

        // Override GetPaginated with custom filtering
        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] ChuyenTruongFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                include: q => q
                    .Include(x => x.CoSo)
                    .Include(x => x.KhoaHoc)
                    .Include(x => x.BacDaoTao)
                    .Include(x => x.LoaiDaoTao)
                    .Include(x => x.NganhHoc)
                    .Include(x => x.SinhVien)
                    .Include(x => x.ChuyenNganh)
                    .Include(x => x.LopHoc),
                filter: q =>
                    (string.IsNullOrEmpty(filter.Keyword) || 
                        q.MaHoSo.ToLower().Contains(filter.Keyword.ToLower()) ||
                        (q.HoTen != null && q.HoTen.ToLower().Contains(filter.Keyword.ToLower())))
                    || (filter.IdCoSo == null || q.IdCoSo == filter.IdCoSo)
                    || (filter.IdKhoaHoc == null || q.IdKhoaHoc == filter.IdKhoaHoc)
                    || (filter.IdBacDaoTao == null || q.IdBacDaoTao == filter.IdBacDaoTao)
                    || (filter.IdLoaiDaoTao == null || q.IdLoaiDaoTao == filter.IdLoaiDaoTao)
                    || (filter.IdNganhHoc == null || q.IdNganhHoc == filter.IdNganhHoc)
                    || (filter.IdSinhVien == null || q.IdSinhVien == filter.IdSinhVien)
                    || (filter.IdChuyenNganh == null || q.IdChuyenNganh == filter.IdChuyenNganh)
                    || (filter.IdLopHoc == null || q.IdLopHoc == filter.IdLopHoc)
                    || (filter.TuTaoMaSinhVien == null || q.TuTaoMaSinhVien == filter.TuTaoMaSinhVien)
                    || (filter.GioiTinh == null || q.GioiTinh == filter.GioiTinh)
                    || (filter.NgaySinhFrom == null || q.NgaySinh >= filter.NgaySinhFrom)
                    || (filter.NgaySinhTo == null || q.NgaySinh <= filter.NgaySinhTo)
            );
            return result.ToResult();
        }
    }

    // Filter class for pagination
    public class ChuyenTruongFilter
    {
        public string? Keyword { get; set; }
        public Guid? IdCoSo { get; set; }
        public Guid? IdKhoaHoc { get; set; }
        public Guid? IdBacDaoTao { get; set; }
        public Guid? IdLoaiDaoTao { get; set; }
        public Guid? IdNganhHoc { get; set; }
        public Guid? IdSinhVien { get; set; }
        public Guid? IdChuyenNganh { get; set; }
        public Guid? IdLopHoc { get; set; }
        public bool? TuTaoMaSinhVien { get; set; }
        public GioiTinhEnum? GioiTinh { get; set; }
        public DateTime? NgaySinhFrom { get; set; }
        public DateTime? NgaySinhTo { get; set; }
    }
}