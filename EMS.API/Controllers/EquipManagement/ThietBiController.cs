using EMS.API.Controllers.Base;
using EMS.Application.Services.EquipService;
using EMS.Application.Services.EquipService.Dtos;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Enums.EquipmentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.EquipManagement
{
    public class ThietBiController : BaseController<TSTBThietBi>
    {
        private readonly IThietBiService _thietBiService;

        public ThietBiController(IThietBiService service) : base(service)
        {
            _thietBiService = service;
        }

        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync();
            return result.ToResult();
        }

        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] ThietBiFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                filter: q =>
                (string.IsNullOrEmpty(filter.MaThietBi) || q.MaThietBi!.ToLower().Contains(filter.MaThietBi.ToLower())) &&
                (string.IsNullOrEmpty(filter.TenThietBi) || q.TenThietBi!.ToLower().Contains(filter.TenThietBi.ToLower())) &&
                (string.IsNullOrEmpty(filter.Model) || q.Model!.ToLower().Contains(filter.Model.ToLower())) &&
                (string.IsNullOrEmpty(filter.SerialNumber) || q.SerialNumber!.ToLower().Contains(filter.SerialNumber.ToLower())) &&
                (string.IsNullOrEmpty(filter.ThongSoKyThuat) || q.ThongSoKyThuat!.ToLower().Contains(filter.ThongSoKyThuat.ToLower())) &&
                (!filter.NamSanXuat.HasValue || (q.NamSanXuat == filter.NamSanXuat)) &&
                (string.IsNullOrEmpty(filter.NgayMua.ToString()) || q.NgayMua!.ToString().ToLower().Contains(filter.NgayMua.ToString().ToLower())) &&
                (string.IsNullOrEmpty(filter.NgayHetHanBaoHanh.ToString()) || q.NgayHetHanBaoHanh!.ToString().ToLower().Contains(filter.NgayHetHanBaoHanh.ToString().ToLower())) &&
                (!filter.NguyenGia.HasValue || q.NguyenGia >= filter.NguyenGia.Value - 0.01m && q.NguyenGia <= filter.NguyenGia.Value + 0.01m) &&
                (!filter.GiaTriKhauHao.HasValue || q.GiaTriKhauHao >= filter.GiaTriKhauHao.Value - 0.01m && q.GiaTriKhauHao <= filter.GiaTriKhauHao.Value + 0.01m) &&
                (filter.TrangThai == null || q.TrangThai == filter.TrangThai) &&
                (string.IsNullOrEmpty(filter.HinhAnhUrl) || q.HinhAnhUrl!.ToLower().Contains(filter.HinhAnhUrl.ToLower())) &&
                (string.IsNullOrEmpty(filter.LoaiThietBiId) || q.LoaiThietBiId!.ToString().ToLower() == filter.LoaiThietBiId.ToLower()) &&
                (string.IsNullOrEmpty(filter.NhaCungCapId) || q.NhaCungCapId!.ToString().ToLower() == filter.NhaCungCapId.ToLower()) &&
                (string.IsNullOrEmpty(filter.PhongHocId) || q.PhongHocId!.ToString().ToLower() == filter.PhongHocId.ToLower()) &&
                (string.IsNullOrEmpty(filter.GhiChu) || q.GhiChu!.ToLower().Contains(filter.GhiChu.ToLower())),
                include: query => query.Include(x => x.LoaiThietBi)
                .Include(x => x.NhaCungCap)
                .Include(x => x.PhongHoc)
            );
            return result.ToResult();
        }

        [HttpPost("nhap-hang-loat")]
        public async Task<IActionResult> NhapHangLoat([FromBody] NhapHangLoatDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _thietBiService.NhapHangLoatAsync(dto);
            return result.Match(
                succ => Ok(succ),
                err => StatusCode(500, new { message = "Lỗi tạo hàng loạt", error = err.Message })
            );
        }

        public class ThietBiFilter
        {
            public string? MaThietBi { get; set; }
            public string? TenThietBi { get; set; }
            public string? Model { get; set; }
            public string? SerialNumber { get; set; }
            public string? ThongSoKyThuat { get; set; }
            public int? NamSanXuat { get; set; }
            public DateTime? NgayMua { get; set; }
            public DateTime? NgayHetHanBaoHanh { get; set; }
            public decimal? NguyenGia { get; set; }
            public decimal? GiaTriKhauHao { get; set; }
            public TrangThaiThietBiEnum? TrangThai { get; set; }
            public string? HinhAnhUrl { get; set; }
            public string? LoaiThietBiId { get; set; }
            public string? NhaCungCapId { get; set; }
            public string? PhongHocId { get; set; }
            public string? GhiChu { get; set; }
        }
    }
}