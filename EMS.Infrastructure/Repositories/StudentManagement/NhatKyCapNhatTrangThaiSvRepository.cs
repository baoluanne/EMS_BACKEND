using System.Linq.Expressions;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories.StudentManagement
{
    public class NhatKyCapNhatTrangThaiSvRepository : AuditRepository<NhatKyCapNhatTrangThaiSv>, INhatKyCapNhatTrangThaiSvRepository
    {
        private DbSet<SinhVien> _sinhVienDbSet;

        public NhatKyCapNhatTrangThaiSvRepository(DbFactory dbFactory) : base(dbFactory)
        {
            _sinhVienDbSet = dbFactory.DbContext.Set<SinhVien>();
        }

        public async Task<PaginationResponse<SinhVien>> PaginateDistinctSinhVienAsync(
            PaginationRequest request,
            Expression<Func<NhatKyCapNhatTrangThaiSv, bool>>? filter = null,
            Expression<Func<SinhVien, object>>? orderBy = null,
            bool isDescending = false,
            Func<IQueryable<SinhVien>, IQueryable<SinhVien>>? include = null)
        {
            var nhatKyQuery = DbSet.AsNoTracking();

            if (filter != null)
                nhatKyQuery = nhatKyQuery.Where(filter);

            if (IsSoftDeletable)
                nhatKyQuery = nhatKyQuery.Where(x => !((ISoftDeletable)x).IsDeleted);

            var distinctSinhVienIds = await nhatKyQuery
                .Where(x => x.IdSinhVien != null)
                .Select(x => x.IdSinhVien)
                .Distinct()
                .ToListAsync();

            var sinhVienQuery = _sinhVienDbSet
                .Where(sv => distinctSinhVienIds.Contains(sv.Id));

            sinhVienQuery = sinhVienQuery
                .Include(sv => sv.CoSoDaoTao)
                .Include(sv => sv.KhoaHoc)
                .Include(sv => sv.BacDaoTao)
                .Include(sv => sv.LoaiDaoTao)
                .Include(sv => sv.Nganh)
                .Include(sv => sv.ChuyenNganh)
                .Include(sv => sv.LopHoc);

            sinhVienQuery = orderBy != null
                ? (isDescending ? sinhVienQuery.OrderByDescending(orderBy) : sinhVienQuery.OrderBy(orderBy))
                : sinhVienQuery.OrderBy(sv => sv.Id);

            var totalCount = await sinhVienQuery.CountAsync();

            var items = await sinhVienQuery
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return new PaginationResponse<SinhVien>
            {
                CurrentPage = request.Page,
                PageSize = request.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (decimal)request.PageSize),
                Result = items
            };
        }
    }
}