using System.Linq.Expressions;
using EMS.API.Controllers.Base;
using EMS.Application.Services.SinhVienNganh2Services;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Enums;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.StudentManagement
{
    public class SinhVienNganh2Controller : BaseController<SinhVienNganh2>
    {
        private readonly ISinhVienNganh2Service _sinhVienNganh2Service;

        public SinhVienNganh2Controller(ISinhVienNganh2Service sinhVienNganh2Service) : base(sinhVienNganh2Service)
        {
            _sinhVienNganh2Service = sinhVienNganh2Service;
        }

        // Override GetAll to include related entities
        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync(q => q
                .Include(x => x.SinhVien)
                .Include(x => x.KhoaHoc)
                .Include(x => x.LopHoc2)
            );
            return result.ToResult();
        }

        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] SinhVienNganh2Filter filter)
        {
            Expression<Func<SinhVienNganh2, bool>> filterExpression = q => true;

            // --- Filter Sinh viên ---
            if (!string.IsNullOrWhiteSpace(filter.MaSinhVien))
                filterExpression = filterExpression.And(q => q.SinhVien != null &&
                                                             EF.Functions.ILike(q.SinhVien.MaSinhVien, $"%{filter.MaSinhVien.Trim()}%"));

            if (!string.IsNullOrWhiteSpace(filter.HoDem))
                filterExpression = filterExpression.And(q => q.SinhVien != null &&
                                                             EF.Functions.ILike(q.SinhVien.HoDem, $"%{filter.HoDem.Trim()}%"));

            if (!string.IsNullOrWhiteSpace(filter.TenSV))
                filterExpression = filterExpression.And(q => q.SinhVien != null &&
                                                             EF.Functions.ILike(q.SinhVien.Ten, $"%{filter.TenSV.Trim()}%"));

            // --- Filter đào tạo ---
            if (filter.IdCoSo != null)
                filterExpression = filterExpression.And(q => q.SinhVien != null && q.SinhVien.IdCoSo == filter.IdCoSo);

            if (filter.IdKhoaHoc != null)
                filterExpression = filterExpression.And(q => q.IdKhoaHoc == filter.IdKhoaHoc);

            if (filter.IdBacDaoTao != null)
                filterExpression = filterExpression.And(q => q.SinhVien != null && q.SinhVien.IdBacDaoTao == filter.IdBacDaoTao);

            if (filter.IdLoaiDaoTao != null)
                filterExpression = filterExpression.And(q => q.SinhVien != null && q.SinhVien.IdLoaiDaoTao == filter.IdLoaiDaoTao);

            if (filter.IdNganh != null)
                filterExpression = filterExpression.And(q => q.SinhVien != null && q.SinhVien.IdNganh == filter.IdNganh);

            if (filter.IdChuyenNganh != null)
                filterExpression = filterExpression.And(q => q.SinhVien != null && q.SinhVien.IdChuyenNganh == filter.IdChuyenNganh);

            if (filter.IdLopHoc != null)
                filterExpression = filterExpression.And(q => q.SinhVien != null && q.SinhVien.IdLopHoc == filter.IdLopHoc);

            if (filter.TrangThai != null)
                filterExpression = filterExpression.And(q => q.SinhVien != null && q.SinhVien.TrangThai == filter.TrangThai);

            IQueryable<SinhVienNganh2> includeFunc(IQueryable<SinhVienNganh2> q)
            {
                return q.Include(x => x.SinhVien).ThenInclude(x => x.NoiSinhTinh)
                        .Include(x => x.KhoaHoc)
                        .Include(x => x.SinhVien).ThenInclude(x => x.LopHoc).ThenInclude(x => x.NganhHoc)
                        .Include(x => x.LopHoc2).ThenInclude(x => x.NganhHoc);
            }

            var result = await Service.GetPaginatedAsync(request, include: includeFunc, filter: filterExpression);
            return result.ToResult();
        }

    }

    // Filter class for pagination
    public class SinhVienNganh2Filter
    {
        public string? MaSinhVien { get; set; }
        public string? HoDem { get; set; }
        public string? TenSV { get; set; }
        public Guid? IdCoSo { get; set; }
        public Guid? IdKhoaHoc { get; set; }
        public Guid? IdBacDaoTao { get; set; }
        public Guid? IdLoaiDaoTao { get; set; }
        public Guid? IdNganh { get; set; }
        public Guid? IdChuyenNganh { get; set; }
        public Guid? IdLopHoc { get; set; } // TODO Filter cho lớp 1 hay lớp 2
        public TrangThaiSinhVienEnum? TrangThai { get; set; }
    }

}