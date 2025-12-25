using EMS.Application.Services.DangKyMonHocServices;
using EMS.Domain.Entities.ClassManagement;
using EMS.API.Controllers.Base;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using EMS.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.ClassManagement;

public class DangKyMonHocController : BaseController<DangKyMonHoc>
{
    public DangKyMonHocController(IDangKyMonHocService dangKyMonHocService) : base(dangKyMonHocService)
    {
    }

    /// <summary>
    /// Get all DangKyMonHoc records with related entities
    /// </summary>
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.SinhVien)
            .Include(x => x.MonHoc)
            .Include(x => x.LopHocPhan)
            .Include(x => x.HocKy)
            .Include(x => x.NamHoc)
            .Include(x => x.NguoiDuyet)
        );
        return result.ToResult();
    }

    /// <summary>
    /// Get paginated DangKyMonHoc records with filtering
    /// </summary>
    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] DangKyMonHocFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q
                .Include(x => x.SinhVien)
                .Include(x => x.MonHoc)
                .Include(x => x.LopHocPhan)
                .Include(x => x.HocKy)
                .Include(x => x.NamHoc)
                .Include(x => x.NguoiDuyet),
            filter: q =>
                (string.IsNullOrEmpty(filter.Keyword) ||
                    q.MaDangKy.ToLower().Contains(filter.Keyword.ToLower()) ||
                    (q.SinhVien != null && (q.SinhVien.MaSinhVien.ToLower().Contains(filter.Keyword.ToLower()) ||
                                           q.SinhVien.Ten.ToLower().Contains(filter.Keyword.ToLower()))) ||
                    (q.MonHoc != null && (q.MonHoc.MaMonHoc.ToLower().Contains(filter.Keyword.ToLower()) ||
                                         q.MonHoc.TenMonHoc.ToLower().Contains(filter.Keyword.ToLower()))) ||
                    (q.LopHocPhan != null && q.LopHocPhan.MaLopHocPhan.ToLower().Contains(filter.Keyword.ToLower())) ||
                    (!string.IsNullOrEmpty(q.DiemChu) && q.DiemChu.ToLower().Contains(filter.Keyword.ToLower())) ||
                    (!string.IsNullOrEmpty(q.LyDoVang) && q.LyDoVang.ToLower().Contains(filter.Keyword.ToLower())) ||
                    (!string.IsNullOrEmpty(q.GhiChu) && q.GhiChu.ToLower().Contains(filter.Keyword.ToLower()))) &&
                (filter.IdSinhVien == null || q.IdSinhVien == filter.IdSinhVien) &&
                (filter.IdMonHoc == null || q.IdMonHoc == filter.IdMonHoc) &&
                (filter.IdLopHocPhan == null || q.IdLopHocPhan == filter.IdLopHocPhan) &&
                (filter.IdHocKy == null || q.IdHocKy == filter.IdHocKy) &&
                (filter.IdNamHoc == null || q.IdNamHoc == filter.IdNamHoc) &&
                (filter.TrangThai == null || q.TrangThai == filter.TrangThai) &&
                (filter.NgayDangKyFrom == null || q.NgayDangKy >= filter.NgayDangKyFrom) &&
                (filter.NgayDangKyTo == null || q.NgayDangKy <= filter.NgayDangKyTo) &&
                (filter.KetQua == null || q.KetQua == filter.KetQua) &&
                (filter.IsMienGiam == null || q.IsMienGiam == filter.IsMienGiam) &&
                (filter.DaDongHocPhi == null || q.DaDongHocPhi == filter.DaDongHocPhi) &&
                (filter.LanHoc == null || q.LanHoc == filter.LanHoc)
        );
        return result.ToResult();
    }
}

/// <summary>
/// Filter class for DangKyMonHoc pagination
/// </summary>
public class DangKyMonHocFilter
{
    public string? Keyword { get; set; }
    public Guid? IdSinhVien { get; set; }
    public Guid? IdMonHoc { get; set; }
    public Guid? IdLopHocPhan { get; set; }
    public Guid? IdHocKy { get; set; }
    public Guid? IdNamHoc { get; set; }
    public TrangThaiDangKy? TrangThai { get; set; }
    public DateTime? NgayDangKyFrom { get; set; }
    public DateTime? NgayDangKyTo { get; set; }
    public bool? KetQua { get; set; }
    public bool? IsMienGiam { get; set; }
    public bool? DaDongHocPhi { get; set; }
    public int? LanHoc { get; set; }
}