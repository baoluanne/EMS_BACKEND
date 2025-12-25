using EMS.API.Controllers.Base;
using EMS.Application.Services.ThoiKhoaBieuServices;
using EMS.Domain.Entities.TimeTable;
using EMS.Domain.Enums;
using EMS.Domain.Extensions;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.TimeTable
{
    public class ThoiKhoaBieuController : BaseController<ThoiKhoaBieu>
    {
        private readonly ISinhVienDangKiHocPhanRepository _dangKiHocPhanRepository;
        private readonly ISinhVienRepository _sinhVienRepository;

        public ThoiKhoaBieuController(
            IThoiKhoaBieuService tkbService,
            ISinhVienDangKiHocPhanRepository dangKiHocPhanRepository,
            ISinhVienRepository sinhVienService) : base(tkbService)
        {
            _dangKiHocPhanRepository = dangKiHocPhanRepository;
            _sinhVienRepository = sinhVienService;
        }

        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync(x => x
                .Include(y => y.LopHocPhan)
                .Include(y => y.PhongHoc)
                .Include(y => y.GiangVien));
            return result.ToResult();
        }

        // Override GetPaginated with custom filtering
        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] ThoiKhoaBieuFilter filter)
        {
            var sinhVien = await _sinhVienRepository.GetSinhVienByMaSVAsync(filter.MaSinhVien);
            if (sinhVien == null)
                return NotFound();

            var lopHocPhans = await _dangKiHocPhanRepository.ListAsync(
                q => q.Include(x => x.LopHocPhan),
                q => q.IdSinhVien == sinhVien.Id && q.LopHocPhan!.IdHocKy == filter.IdDot);
            var lopHocPhanIds = lopHocPhans.Select(x => x.IdLopHocPhan).ToList();

            var result = await Service.GetPaginatedAsync(
                request,
                include: q => q
                    .Include(x => x.LopHocPhan)
                    .Include(x => x.LopHocPhan).ThenInclude(x => x.MonHoc)
                    .Include(x => x.LopHocPhan).ThenInclude(x => x.HocKy)
                    .Include(x => x.LopHocPhan).ThenInclude(x => x.KhoaHoc)
                    .Include(x => x.PhongHoc)
                    .Include(x => x.GiangVien),
                filter: f => lopHocPhanIds.Contains(f.IdLopHocPhan) &&
                             (!filter.TrangThai.HasValue || f.LopHocPhan!.TrangThai == filter.TrangThai)
            );
            return result.ToResult();
        }
    }

    public class ThoiKhoaBieuFilter
    {
        public LoaiLich? LoaiLich { get; set; }
        public Guid IdDot { get; set; }
        public TrangThaiLopHocPhanEnum? TrangThai { get; set; }
        public string MaSinhVien { get; set; }
    }
}