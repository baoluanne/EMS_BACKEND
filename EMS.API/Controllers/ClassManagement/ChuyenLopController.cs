using EMS.API.Controllers.Base;
using EMS.Application.Services.ChuyenLopServices;
using EMS.Application.Services.ChuyenLopServices.Dtos;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Enums;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.ClassManagement;

public class ChuyenLopController : BaseController<ChuyenLop>
{
    private readonly IChuyenLopService _chuyenLopService;

    public ChuyenLopController(IChuyenLopService chuyenLopService) : base(chuyenLopService)
    {
        _chuyenLopService = chuyenLopService;
    }

    // Override GetAll to include related entities
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.SinhVien)
            .Include(x => x.LopCu)
            .Include(x => x.LopMoi)
            .Include(x => x.QuyetDinh)
        );
        return result.ToResult();
    }

    // Override GetPaginated with custom filtering
    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] ChuyenLopFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q.Include(x => x.SinhVien)
                .Include(x => x.LopCu).ThenInclude(x => x.BacDaoTao)
                .Include(x => x.LopCu).ThenInclude(x => x.LoaiDaoTao)
                .Include(x => x.LopCu).ThenInclude(x => x.NganhHoc)
                .Include(x => x.LopMoi).ThenInclude(x => x.BacDaoTao)
                .Include(x => x.LopMoi).ThenInclude(x => x.LoaiDaoTao)
                .Include(x => x.LopMoi).ThenInclude(x => x.NganhHoc)
                .Include(x => x.QuyetDinh),
            filter: q =>
                (filter.IdSinhVien == null || q.IdSinhVien == filter.IdSinhVien)
                && (filter.IdLopCu == null || q.IdLopCu == filter.IdLopCu)
                && (filter.IdLopMoi == null || q.IdLopMoi == filter.IdLopMoi)
                && (filter.IdQuyetDinh == null || q.IdQuyetDinh == filter.IdQuyetDinh)
                && (string.IsNullOrEmpty(filter.SoQuyetDinh) ||
                    q.SoQuyetDinh != null && q.SoQuyetDinh.ToLower().Contains(filter.SoQuyetDinh.ToLower()))
                && (string.IsNullOrEmpty(filter.MaLopHocCu) ||
                    q.LopCu != null && q.LopCu.MaLop.ToLower().Contains(filter.MaLopHocCu.ToLower()))
                && (string.IsNullOrEmpty(filter.MaLopHocMoi) ||
                    q.LopMoi != null && q.LopMoi.MaLop.ToLower().Contains(filter.MaLopHocMoi.ToLower()))
                && (filter.NgayChuyenLopFrom == null || q.NgayChuyenLop >= filter.NgayChuyenLopFrom)
                && (filter.NgayChuyenLopTo == null || q.NgayChuyenLop <= filter.NgayChuyenLopTo)
                && (filter.NgayRaQuyetDinhFrom == null ||
                    (q.NgayRaQuyetDinh != null && q.NgayRaQuyetDinh >= filter.NgayRaQuyetDinhFrom))
                && (filter.NgayRaQuyetDinhTo == null ||
                    (q.NgayRaQuyetDinh != null && q.NgayRaQuyetDinh <= filter.NgayRaQuyetDinhTo))
                && (filter.PhanLoaiChuyenLop == null || q.PhanLoaiChuyenLop == filter.PhanLoaiChuyenLop)
                && (string.IsNullOrEmpty(filter.TrichYeu) ||
                    q.TrichYeu != null && q.TrichYeu.ToLower().Contains(filter.TrichYeu.ToLower()))
                && (string.IsNullOrEmpty(filter.GhiChu) ||
                    q.GhiChu != null && q.GhiChu.ToLower().Contains(filter.GhiChu.ToLower()))
                && (string.IsNullOrEmpty(filter.MaSVAndHoTenSV) ||
                    q.SinhVien!.HoDem.ToLower().Contains(filter.MaSVAndHoTenSV.ToLower()) ||
                    q.SinhVien!.Ten.ToLower().Contains(filter.MaSVAndHoTenSV.ToLower()) ||
                    q.SinhVien!.MaSinhVien.ToLower().Contains(filter.MaSVAndHoTenSV.ToLower()) ||
                    (q.SinhVien.HoDem + " " + q.SinhVien!.Ten.ToLower()).Contains(filter.MaSVAndHoTenSV.ToLower())
                ));
        return result.ToResult();
    }

    [HttpPost("chuyen-lop")]
    public virtual async Task<IActionResult> TransferStudents(TransferStudentsRequestDto request)
    {
        var results = await _chuyenLopService.TransferStudents(request);
        return Ok(results);
    }

    [HttpPost("chuyen-lop-tu-do")]
    public virtual async Task<IActionResult> ChuyenLopTuDo(ChuyenLopTuDoRequestDto request)
    {
        var results = await _chuyenLopService.ChuyenLopTuDoAsync(request);
        return Ok(results);
    }

    [HttpGet("hoc-phan-cu")]
    public async Task<IActionResult> GetHocPhanCu(
        [FromQuery] PaginationRequest request,
        [FromQuery] Guid idSinhVien)
    {
        try
        {
            var result = await _chuyenLopService.GetDanhSachHocPhanCuAsync(idSinhVien);
            return result.ToResult();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("hoc-phan-moi")]
    public async Task<IActionResult> GetHocPhanMoi([FromQuery] PaginationRequest request,
        [FromQuery] Guid idSinhVien,
        [FromQuery] Guid idLopHocMoi)
    {
        try
        {
            if (idLopHocMoi == Guid.Empty)
                return BadRequest("Vui lòng chọn lớp mới.");

            var result = await _chuyenLopService.GetDanhSachHocPhanMoiAsync(idSinhVien, idLopHocMoi);
            return result.ToResult();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

// Filter class for pagination
public class ChuyenLopFilter
{
    public Guid? IdSinhVien { get; set; }
    public Guid? IdLopCu { get; set; }
    public Guid? IdLopMoi { get; set; }
    public Guid? IdQuyetDinh { get; set; }
    public string? SoQuyetDinh { get; set; }
    public DateTime? NgayChuyenLopFrom { get; set; }
    public DateTime? NgayChuyenLopTo { get; set; }
    public DateTime? NgayRaQuyetDinhFrom { get; set; }
    public DateTime? NgayRaQuyetDinhTo { get; set; }
    public PhanLoaiChuyenLopEnum? PhanLoaiChuyenLop { get; set; }
    public string? TrichYeu { get; set; }
    public string? GhiChu { get; set; }
    public string? MaSVAndHoTenSV { get; set; }
    public string? MaLopHocCu { get; set; }
    public string? MaLopHocMoi { get; set; }
}