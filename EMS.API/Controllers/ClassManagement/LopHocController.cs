using System.Linq.Expressions;
using EMS.API.Controllers.Base;
using EMS.Application.Services.LopHocServices;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.ClassManagement
{
    public class LopHocController : BaseController<LopHoc>
    {
        public LopHocController(ILopHocService service) : base(service)
        {
        }

        // Override GetAll to include related entities
        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync(q => q
                .Include(x => x.CoSoDaoTao)
                .Include(x => x.KhoaHoc)
                .Include(x => x.BacDaoTao)
                .Include(x => x.LoaiDaoTao)
                .Include(x => x.NganhHoc)
                .Include(x => x.ChuyenNganh)
                .Include(x => x.Khoa)
                .Include(x => x.GiangVienChuNhiem)
                .Include(x => x.CoVanHocTap)
                .Include(x => x.CaHoc)
            );
            return result.ToResult();
        }

        // Override GetPaginated with custom filtering
        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] LopHocFilter filter)
        {
            var lowerKeyword = filter.Keyword?.ToLower();
            var lowerTenLop = filter.TenLop?.ToLower();
            var result = await Service.GetPaginatedAsync(
                request,
                include: q => q
                    .Include(x => x.CoSoDaoTao)
                    .Include(x => x.KhoaHoc)
                    .Include(x => x.BacDaoTao)
                    .Include(x => x.LoaiDaoTao)
                    .Include(x => x.NganhHoc)
                    .Include(x => x.ChuyenNganh)
                    .Include(x => x.Khoa)
                    .Include(x => x.GiangVienChuNhiem)
                    .Include(x => x.CoVanHocTap)
                    .Include(x => x.CaHoc),
                filter: q =>
                    // filter ids
                    (filter.IdCoSoDaoTao == null || q.IdCoSoDaoTao == filter.IdCoSoDaoTao)
                    && (filter.IdKhoaHoc == null || q.IdKhoaHoc == filter.IdKhoaHoc)
                    && (filter.IdBacDaoTao == null || q.IdBacDaoTao == filter.IdBacDaoTao)
                    && (filter.IdLoaiDaoTao == null || q.IdLoaiDaoTao == filter.IdLoaiDaoTao)
                    && (filter.IdNganhHoc == null || q.IdNganhHoc == filter.IdNganhHoc)
                    && (filter.IdChuyenNganh == null || q.IdChuyenNganh == filter.IdChuyenNganh)
                    && (filter.IdKhoa == null || q.IdKhoa == filter.IdKhoa)
                    && (string.IsNullOrEmpty(filter.TenLop) || q.TenLop.ToLower().Contains(filter.TenLop.ToLower()))
                    && (string.IsNullOrEmpty(filter.SoHopDong) || q.SoHopDong!.ToLower().Contains(filter.SoHopDong!.ToLower()))
                    && (string.IsNullOrEmpty(filter.SoQuyetDinhThanhLapLop) || q.SoQuyetDinhThanhLapLop!.ToLower().Contains(filter.SoQuyetDinhThanhLapLop!.ToLower()))
                    // Filter by date ranges
                    && (filter.NgayHopDongFrom == null ||
                        (q.NgayHopDong != null && q.NgayHopDong >= filter.NgayHopDongFrom))
                    && (filter.NgayHopDongTo == null ||
                        (q.NgayHopDong != null && q.NgayHopDong <= filter.NgayHopDongTo))
                    && (filter.NgayRaQuyetDinhFrom == null ||
                        (q.NgayRaQuyetDinh != null && q.NgayRaQuyetDinh >= filter.NgayRaQuyetDinhFrom))
                    && (filter.NgayRaQuyetDinh == null ||
                        (q.NgayRaQuyetDinh != null && q.NgayRaQuyetDinh == filter.NgayRaQuyetDinh))
                    && (filter.NgayRaQuyetDinhTo == null ||
                        (q.NgayRaQuyetDinh != null && q.NgayRaQuyetDinh <= filter.NgayRaQuyetDinhTo))


            );
            return result.ToResult();
        }
        [HttpGet("lop-hoc-chuong-trinh-khung")]
        public virtual async Task<IActionResult> GetLopHocCTKPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] LopHocChuongTrinhKhungFilter filter)
        {
            var predicates = new List<Expression<Func<LopHoc, bool>>>();

            if (filter.IdCoSoDaoTao != null)
                predicates.Add(q => q.IdCoSoDaoTao == filter.IdCoSoDaoTao);
            if (filter.IdKhoaHoc != null)
                predicates.Add(q => q.IdKhoaHoc == filter.IdKhoaHoc);
            if (filter.IdBacDaoTao != null)
                predicates.Add(q => q.IdBacDaoTao == filter.IdBacDaoTao);
            if (filter.IdLoaiDaoTao != null)
                predicates.Add(q => q.IdLoaiDaoTao == filter.IdLoaiDaoTao);
            if (filter.IdNganhHoc != null)
                predicates.Add(q => q.IdNganhHoc == filter.IdNganhHoc);
            if (filter.IdChuyenNganh != null)
                predicates.Add(q => q.IdChuyenNganh == filter.IdChuyenNganh);

            Expression<Func<LopHoc, bool>> filterExpression;

            if (predicates.Count == 0)
            {
                filterExpression = q => false;
            }
            else
            {
                filterExpression = predicates.Aggregate((a, b) => a.And(b));
            }

            var result = await Service.GetPaginatedAsync(
                request,
                filter: filterExpression
            );
            return result.ToResult();
        }
    }
}

// Filter class for pagination
public class LopHocFilter
{
    public string? Keyword { get; set; }
    public string? TenLop { get; set; }
    public string? SoHopDong { get; set; }
    public string? SoQuyetDinhThanhLapLop { get; set; }
    // Foreign key filters
    public Guid? IdCoSoDaoTao { get; set; }
    public Guid? IdKhoaHoc { get; set; }
    public Guid? IdBacDaoTao { get; set; }
    public Guid? IdLoaiDaoTao { get; set; }
    public Guid? IdNganhHoc { get; set; }
    public Guid? IdChuyenNganh { get; set; }
    public Guid? IdKhoa { get; set; }
    public Guid? IdGiangVienChuNhiem { get; set; }
    public Guid? IdCoVanHocTap { get; set; }
    public Guid? IDCaHoc { get; set; }

    // Boolean filters
    public bool? IsVisible { get; set; }

    // Date range filters
    public DateTime? NgayHopDongFrom { get; set; }
    public DateTime? NgayHopDongTo { get; set; }
    public DateTime? NgayRaQuyetDinhFrom { get; set; }
    public DateTime? NgayRaQuyetDinh { get; set; }
    public DateTime? NgayRaQuyetDinhTo { get; set; }
}

public class LopHocChuongTrinhKhungFilter
{
    // Foreign key filters
    public Guid? IdCoSoDaoTao { get; set; }
    public Guid? IdKhoaHoc { get; set; }
    public Guid? IdBacDaoTao { get; set; }
    public Guid? IdLoaiDaoTao { get; set; }
    public Guid? IdNganhHoc { get; set; }
    public Guid? IdChuyenNganh { get; set; }
}