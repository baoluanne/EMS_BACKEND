using EMS.API.Controllers.Base;
using EMS.Application.Services.NhatKyCapNhatTrangThaiSvServices;
using EMS.Application.Services.NhatKyCapNhatTrangThaiSvServices.Dtos;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Enums;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.StudentManagement
{
    public class NhatKyCapNhatTrangThaiSvController : BaseController<NhatKyCapNhatTrangThaiSv>
    {
        private readonly INhatKyCapNhatTrangThaiSvService _service;

        public NhatKyCapNhatTrangThaiSvController(INhatKyCapNhatTrangThaiSvService service) : base(service)
        {
            _service = service;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync(q => q.
                Include(x => x.SinhVien));
            return result.ToResult();
        }

        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination([FromQuery] PaginationRequest request, [FromQuery] NhatKyCapNhatTrangThaiSvFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                include: q => q.Include(x => x.SinhVien),
                filter: x =>
                    (filter.IdSinhVien == null || x.IdSinhVien == filter.IdSinhVien) ||
                    (x.TrangThaiCu == filter.TrangThaiCu) ||
                    (x.TrangThaiMoi == filter.TrangThaiMoi) ||
                    (string.IsNullOrEmpty(filter.SoQuyetDinh) || x.SoQuyetDinh.Contains(filter.SoQuyetDinh)) ||
                    (filter.NgayQuyetDinhFrom == null || x.NgayQuyetDinh >= filter.NgayQuyetDinhFrom) ||
                    (filter.NgayQuyetDinhTo == null || x.NgayQuyetDinh <= filter.NgayQuyetDinhTo) ||
                    (filter.IdQuyetDinh == null || x.IdQuyetDinh == filter.IdQuyetDinh) ||
                    (filter.NgayHetHanFrom == null || x.NgayHetHan >= filter.NgayHetHanFrom) ||
                    (filter.NgayHetHanTo == null || x.NgayHetHan <= filter.NgayHetHanTo)
            );

            return result.ToResult();
        }

        [HttpGet("pagination/sinhvien")]
        public virtual async Task<IActionResult> GetPaginationSinhVien(
            [FromQuery] PaginationRequest request,
            [FromQuery] NhatKyCapNhatTrangThaiSvFilter filter)
        {
            var result = await _service.PaginateDistinctSinhVienAsync(
                request,
                include: q => q
                    .Include(sv => sv.CoSoDaoTao)
                    .Include(sv => sv.KhoaHoc)
                    .Include(sv => sv.BacDaoTao)
                    .Include(sv => sv.LoaiDaoTao)
                    .Include(sv => sv.Nganh)
                    .Include(sv => sv.ChuyenNganh)
                    .Include(sv => sv.LopHoc),
                filter: x =>
                    (filter.IdSinhVien == null || x.IdSinhVien == filter.IdSinhVien) &&
                    (filter.TrangThaiCu == null || x.TrangThaiCu == filter.TrangThaiCu) &&
                    (filter.TrangThaiMoi == null || x.TrangThaiMoi == filter.TrangThaiMoi) &&
                    (string.IsNullOrEmpty(filter.SoQuyetDinh) || x.SoQuyetDinh.Contains(filter.SoQuyetDinh)) &&
                    (filter.NgayQuyetDinhFrom == null || x.NgayQuyetDinh >= filter.NgayQuyetDinhFrom) &&
                    (filter.NgayQuyetDinhTo == null || x.NgayQuyetDinh <= filter.NgayQuyetDinhTo) &&
                    (filter.NgayHetHanFrom == null || x.NgayHetHan >= filter.NgayHetHanFrom) &&
                    (filter.NgayHetHanTo == null || x.NgayHetHan <= filter.NgayHetHanTo) &&
                    (filter.IdQuyetDinh == null || x.IdQuyetDinh == filter.IdQuyetDinh) &&
                    (filter.NgayTaoFrom == null || x.NgayTao >= filter.NgayTaoFrom) &&
                    (filter.NgayTaoTo == null || x.NgayTao <= filter.NgayTaoTo) &&
                    (string.IsNullOrEmpty(filter.NguoiCapNhat) || x.NguoiCapNhat == null || x.NguoiCapNhat.Ten.Contains(filter.NguoiCapNhat)) &&
                    (string.IsNullOrEmpty(filter.GhiChu) || x.GhiChu!.ToLower().Contains(filter.GhiChu.ToLower())) &&

                    (string.IsNullOrEmpty(filter.MaSinhVien) || x.SinhVien!.MaSinhVien.Contains(filter.MaSinhVien)) &&
                    (string.IsNullOrEmpty(filter.HoTen) ||
                        (x.SinhVien!.HoDem + " " + x.SinhVien!.Ten).Contains(filter.HoTen)) &&
                    (filter.IdCoSo == null || x.SinhVien!.IdCoSo == filter.IdCoSo) &&
                    (filter.IdKhoaHoc == null || x.SinhVien!.IdKhoaHoc == filter.IdKhoaHoc) &&
                    (filter.IdKhoa == null || x.SinhVien!.LopHoc!.IdKhoa == filter.IdKhoa) &&
                    (filter.IdBacDaoTao == null || x.SinhVien!.IdBacDaoTao == filter.IdBacDaoTao) &&
                    (filter.IdLoaiDaoTao == null || x.SinhVien!.IdLoaiDaoTao == filter.IdLoaiDaoTao) &&
                    (filter.IdNganh == null || x.SinhVien!.IdNganh == filter.IdNganh) &&
                    (filter.IdChuyenNganh == null || x.SinhVien!.IdChuyenNganh == filter.IdChuyenNganh) &&
                    (filter.IdLopHoc == null || x.SinhVien!.IdLopHoc == filter.IdLopHoc)
            );

            return result.ToResult();
        }

        [HttpGet("SinhVien/{idSinhVien:Guid}")]
        public virtual async Task<IActionResult> GetByIdSinhVien([FromQuery] PaginationRequest request, [FromRoute] Guid idSinhVien)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                include: q => q
                    .Include(x => x.SinhVien)
                    .Include(x => x.QuyetDinh),
                filter: x => x.IdSinhVien == idSinhVien
            );

            return result.ToResult();
        }

        [HttpPost("SinhVien/multiple")]
        public virtual async Task<IActionResult> CreateMultiple([FromBody] CapNhatTrangThaiSinhVien request)
        {
            var result = await _service.CreateNhatKyCapNhatSinhVienAsync(request);
            return result.ToResult();
        }
    }

    public class NhatKyCapNhatTrangThaiSvFilter
    {
        public Guid? IdSinhVien { get; set; }
        public TrangThaiSinhVienEnum? TrangThaiCu { get; set; }
        public TrangThaiSinhVienEnum? TrangThaiMoi { get; set; }
        public string? SoQuyetDinh { get; set; }
        public DateTime? NgayQuyetDinhFrom { get; set; }
        public DateTime? NgayQuyetDinhTo { get; set; }
        public Guid? IdQuyetDinh { get; set; }
        public DateTime? NgayHetHanFrom { get; set; }
        public DateTime? NgayHetHanTo { get; set; }

        public DateTime? NgayTaoFrom { get; set; }
        public DateTime? NgayTaoTo { get; set; }
        public string? NguoiCapNhat { get; set; }

        public string? MaSinhVien { get; set; }
        public string? HoTen { get; set; }
        public string? GhiChu { get; set; }

        public Guid? IdCoSo { get; set; }
        public Guid? IdKhoaHoc { get; set; }
        public Guid? IdKhoa { get; set; }
        public Guid? IdBacDaoTao { get; set; }
        public Guid? IdLoaiDaoTao { get; set; }
        public Guid? IdNganh { get; set; }
        public Guid? IdChuyenNganh { get; set; }
        public Guid? IdLopHoc { get; set; }
    }
}