using EMS.API.Controllers.Base;
using EMS.Application.Services.TiepNhanHoSoSvServices;
using EMS.Application.Services.TiepNhanHoSoSvServices.Dtos;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.StudentManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiepNhanHoSoSvController : BaseController<TiepNhanHoSoSv>
    {
        private readonly ITiepNhanHoSoSvService _service;

        public TiepNhanHoSoSvController(ITiepNhanHoSoSvService service) : base(service)
        {
            _service = service;
        }

        // Override GetAll to include related entities
        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync(q => q
                .Include(x => x.SinhVien)
                .Include(x => x.HoSoSV)
                .Include(x => x.NguoiTiepNhan)
            );
            return result.ToResult();
        }

        // Override GetPaginated with custom filtering
        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] TiepNhanHoSoSvFilterRequestDto filter)
        {
            var result = await _service.GetListPaginatedAsync(request, filter);
            return result.ToResult();
        }

        [HttpPost("update-tiep-nhan-ho-so")]
        public virtual async Task<IActionResult> UpdateTiepNhanHoSoSinhVien(
            [FromBody] UpdateTiepNhanHoSoSinhVienRequestDto body)
        {
            var result = await _service.UpdateHoSoAsync(body.DanhSachHoSoSV);
            return result.ToResult();
        }

        [HttpGet("thong-ke/pagination")]
        public virtual async Task<IActionResult> GetThongKeTiepNhanHoSoSvPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] ThongKeTiepNhanHoSoSvFilter filter)
        {
            var result = await _service.GetPaginatedAsync(
                request,
                include: q => q
                    .Include(x => x.SinhVien)
                        .ThenInclude(s => s.LopHoc)
                    .Include(x => x.HoSoSV)
                    .Include(x => x.NguoiTiepNhan)
                    .Include(x => x.NguoiXuLy),
                filter: q =>
                    // Student-related filters
                    (filter.IdCoSo == null || (q.SinhVien != null && q.SinhVien.IdCoSo == filter.IdCoSo))
                    && (filter.IdKhoaHoc == null || (q.SinhVien != null && q.SinhVien.IdKhoaHoc == filter.IdKhoaHoc))
                    && (filter.IdBacDaoTao == null || (q.SinhVien != null && q.SinhVien.IdBacDaoTao == filter.IdBacDaoTao))
                    && (filter.IdLoaiDaoTao == null || (q.SinhVien != null && q.SinhVien.IdLoaiDaoTao == filter.IdLoaiDaoTao))
                    && (filter.IdNganhHoc == null || (q.SinhVien != null && q.SinhVien.LopHoc != null && q.SinhVien.LopHoc.IdNganhHoc == filter.IdNganhHoc))
                    && (filter.IdChuyenNganh == null || (q.SinhVien != null && q.SinhVien.LopHoc != null && q.SinhVien.LopHoc.IdChuyenNganh == filter.IdChuyenNganh))
                    && (filter.IdLopHoc == null || (q.SinhVien != null && q.SinhVien.IdLopHoc == filter.IdLopHoc))
                    && (string.IsNullOrEmpty(filter.MaSinhVien) || (q.SinhVien != null && q.SinhVien.MaSinhVien.Contains(filter.MaSinhVien)))
                    && (string.IsNullOrEmpty(filter.HoTen) || (q.SinhVien != null && (q.SinhVien.HoDem + " " + q.SinhVien.Ten).Contains(filter.HoTen)))
                    // HoSo-related filters
                    && (filter.IdHoSo == null || q.IdHoSoSV == filter.IdHoSo)
                    && (filter.LoaiHoSo == null || (q.HoSoSV != null && q.HoSoSV.LoaiHoSo == filter.LoaiHoSo))
                    // Status filter (allow multiple statuses)
                    && (filter.TrangThaiHoSo == null || filter.TrangThaiHoSo.Count == 0 || filter.TrangThaiHoSo.Contains(q.TrangThai))
                    // Date range filter
                    && (filter.NgayTiepNhanHoSoFrom == null || q.NgayTiepNhan >= filter.NgayTiepNhanHoSoFrom)
                    && (filter.NgayTiepNhanHoSoTo == null || q.NgayTiepNhan <= filter.NgayTiepNhanHoSoTo)
            );
            return result.ToResult();
        }
    }
}