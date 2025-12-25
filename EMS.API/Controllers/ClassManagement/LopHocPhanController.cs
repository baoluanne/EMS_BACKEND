using System.Linq.Expressions;
using EMS.API.Controllers.Base;
using EMS.Application.Services.LopHocPhanServices;
using EMS.Application.Services.LopHocPhanServices.Dtos;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Enums;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.ClassManagement
{
    public class LopHocPhanController : BaseController<LopHocPhan>
    {
        public LopHocPhanController(ILopHocPhanService service) : base(service) { }

        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync(q => q
                    .Include(x => x.MonHoc)
                    .Include(x => x.HocKy)
                    .Include(x => x.CoSo)
                    .Include(x => x.BacDaoTao)
                    .Include(x => x.LoaiDaoTao)
                    .Include(x => x.KhoaHoc)
                    .Include(x => x.KhoaChuQuan)
                    .Include(x => x.LoaiMonHoc)
            );
            return result.ToResult();
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] LopHocPhanFilter filter)
        {
            // Define includes needed for filtering and display
            Expression<Func<IQueryable<LopHocPhan>, IQueryable<LopHocPhan>>> includeExpression = q => q
                .Include(x => x.MonHoc)
                .Include(x => x.HocKy)
                .Include(x => x.CoSo)
                .Include(x => x.BacDaoTao)
                .Include(x => x.LoaiDaoTao)
                .Include(x => x.KhoaChuQuan)
                .Include(x => x.KhoaHoc);

            // Define the filter expression
            Expression<Func<LopHocPhan, bool>> filterExpression = q =>
                    (string.IsNullOrEmpty(filter.MaLHP) || q.MaLopHocPhan.ToLower().Contains(filter.MaLHP.ToLower()))
                    || (q.TenLopHocPhan.ToLower().Contains(filter.TenLopHocPhan))
                    || q.HocKy!.TenDot == filter.Dot
                    || (filter.CoSoDaoTao == null || q.CoSo!.TenCoSo.ToLower().Contains(filter.CoSoDaoTao.ToLower()))
                    || (filter.KhoaHoc == null || q.KhoaHoc!.TenKhoaHoc.ToLower().Contains(filter.KhoaHoc.ToLower()))
                    || (filter.BacDaoTao == null || q.BacDaoTao!.TenBacDaoTao.Contains(filter.BacDaoTao.ToLower()))
                    || (filter.LoaiDaoTao == null || q.LoaiDaoTao!.TenLoaiDaoTao.ToLower().Contains(filter.LoaiDaoTao.ToLower()))
                    || (filter.KhoaChuQuan == null || q.KhoaChuQuan!.TenKhoa.ToLower().Contains(filter.KhoaChuQuan.ToLower()))
                    || (filter.TenMonHoc == null || q.MonHoc!.TenMonHoc.ToLower().Contains(filter.TenMonHoc.ToLower()))
                    || (filter.LoaiMonHoc == null || q.LoaiMonHoc!.TenLoaiMonHoc.ToLower().Contains(filter.LoaiMonHoc.ToLower()))
                    || (filter.LoaiLHP == null || q.LoaiLHP == filter.LoaiLHP)
                    || (filter.TrangThaiLHP == null || q.TrangThai == filter.TrangThaiLHP)
                    || (string.IsNullOrEmpty(filter.LopBanDau) || (q.LopBanDau != null && q.LopBanDau.ToLower().Contains(filter.LopBanDau.ToLower())))
                    || (filter.MaLopDanhNghia == null || q.DangKyHocPhans.Any(dk => dk.SinhVien != null && dk.SinhVien.LopHoc!.MaLop == filter.MaLopDanhNghia))
                    || (filter.NgayHocCuoiTu == null || q.NgayKetThuc >= filter.NgayHocCuoiTu)
                    || (filter.NgayHocCuoiDen == null || q.NgayKetThuc <= filter.NgayHocCuoiDen);

            var result = await Service.GetPaginatedAsync(
                request,
                include: q => q
                    .Include(x => x.MonHoc)
                    .Include(x => x.HocKy)
                    .Include(x => x.CoSo)
                    .Include(x => x.BacDaoTao)
                    .Include(x => x.LoaiDaoTao)
                    .Include(x => x.KhoaChuQuan)
                    .Include(x => x.KhoaHoc),
                filter: filterExpression
            );

            return result.ToResult();
        }

        [HttpGet("tim-kiem-lop-hoc-phan")]
        public virtual async Task<IActionResult> GetLHPPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] TimKiemLopHocPhanFilterRequestDto filter)
        {
            Expression<Func<LopHocPhan, bool>> filterExpression = lhp => lhp.IdHocKy == filter.IdHocKy;

            if (!string.IsNullOrWhiteSpace(filter.MaLHP))
                filterExpression = filterExpression.And(lhp => lhp.MaLopHocPhan.Contains(filter.MaLHP));

            if (!string.IsNullOrWhiteSpace(filter.TenLopHocPhan))
                filterExpression = filterExpression.And(lhp => lhp.MaLopHocPhan.Contains(filter.TenLopHocPhan));

            if (filter.IdKhoaChuQuan != null)
                filterExpression = filterExpression.And(lhp => lhp.IdKhoaChuQuan == filter.IdKhoaChuQuan);

            if (filter.IdCoSo != null)
                filterExpression = filterExpression.And(lhp => lhp.IdCoSo == filter.IdCoSo);

            if (filter.IdKhoaHoc != null)
                filterExpression = filterExpression.And(lhp => lhp.IdKhoaHoc == filter.IdKhoaHoc);

            if (filter.IdBacDaoTao != null)
                filterExpression = filterExpression.And(lhp => lhp.IdBacDaoTao == filter.IdBacDaoTao);

            if (filter.IdLoaiDaoTao != null)
                filterExpression = filterExpression.And(lhp => lhp.IdLoaiDaoTao == filter.IdLoaiDaoTao);

            if (!string.IsNullOrWhiteSpace(filter.TenMonHoc))
                filterExpression = filterExpression.And(lhp => lhp.MonHoc!.TenMonHoc.Contains(filter.TenMonHoc));

            if (filter.LoaiLHP != null)
                filterExpression = filterExpression.And(lhp => lhp.LoaiLHP == filter.LoaiLHP);

            if (filter.IdLoaiMonHoc != null)
                filterExpression = filterExpression.And(lhp => lhp.MonHoc!.IdLoaiMonHoc == filter.IdLoaiMonHoc);

            if (filter.IdHinhThucThi != null)
                filterExpression = filterExpression.And(lhp => lhp.IdHinhThucThi == filter.IdHinhThucThi);

            if (filter.LoaiMonLTTH != null)
                filterExpression = filterExpression.And(lhp => lhp.LoaiMonLTTH == filter.LoaiMonLTTH);

            if (filter.TrangThaiLHP != null)
                filterExpression = filterExpression.And(lhp => lhp.TrangThai == filter.TrangThaiLHP);

            if (filter.NgayHocCuoiTu != null)
                filterExpression = filterExpression.And(lhp => lhp.NgayKetThuc >= filter.NgayHocCuoiTu);

            if (filter.NgayHocCuoiDen != null)
                filterExpression = filterExpression.And(lhp => lhp.NgayKetThuc <= filter.NgayHocCuoiDen);

            if (!string.IsNullOrWhiteSpace(filter.LopBanDau))
                filterExpression = filterExpression.And(lhp =>
                    lhp.LopDuKiens != null && lhp.LopDuKiens.Any(ldk => ldk.LopDuKien!.TenLop.Contains(filter.LopBanDau)));

            // Bộ lọc theo ngành, chuyên ngành hoặc lớp danh nghĩa
            if (filter.IdNganh != null || filter.IdChuyenNganh != null || filter.IdLopDanhNghia != null)
            {
                filterExpression = filterExpression.And(lhp =>
                    lhp.DangKyHocPhans.Any(dk =>
                        (filter.IdNganh == null || dk.SinhVien!.IdNganh == filter.IdNganh) &&
                        (filter.IdChuyenNganh == null || dk.SinhVien!.IdChuyenNganh == filter.IdChuyenNganh) &&
                        (filter.IdLopDanhNghia == null || dk.SinhVien!.IdLopHoc == filter.IdLopDanhNghia)
                    )
                );
            }
            IQueryable<LopHocPhan> includeFunc(IQueryable<LopHocPhan> q)
            {
                return q.AsNoTracking()
                .Include(lhp => lhp.GiangVien)
                .Include(lhp => lhp.LopDuKiens).ThenInclude(ldk => ldk.LopDuKien)
                .Include(lhp => lhp.KhoaChuQuan)
                .Include(lhp => lhp.CoSo)
                .Include(lhp => lhp.MonHoc);
            }

            var result = await Service.GetPaginatedAsync(request, include: includeFunc, filter: filterExpression);
            return result.ToResult();
        }
    }

    public class LopHocPhanFilter
    {
        public string? MaLHP { get; set; }
        public string? TenLopHocPhan { get; set; }
        public string? CoSoDaoTao { get; set; }
        public string? LoaiDaoTao { get; set; }

        public string? MaLopDanhNghia { get; set; }
        public LoaiLHPEnum? LoaiLHP { get; set; }
        public LoaiMonLTTHEnum? LoaiMonLTTH { get; set; }
        public string? NamHoc { get; set; }
        public string? Dot { get; set; }
        public string? KhoaHoc { get; set; }
        public string? BacDaoTao { get; set; }
        public string? TenMonHoc { get; set; } // Added for filtering by MonHoc name
        public string? LoaiMonHoc { get; set; } // Added
        public string? HinhThucThi { get; set; } // Renamed from IdHinhThucThi, assuming enum
        public TrangThaiLopHocPhanEnum? TrangThaiLHP { get; set; }
        public string? LopBanDau { get; set; }
        public DateTime? NgayHocCuoiTu { get; set; } // Assuming this filters NgayKetThuc
        public DateTime? NgayHocCuoiDen { get; set; } // Assuming this filters NgayKetThuc
        public string? KhoaChuQuan { get; set; }
        public int? Nhom { get; set; }
    }
}