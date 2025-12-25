using System.Data.Entity;
using EMS.Domain.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Entities.Views;
using EMS.Domain.Interfaces.Repositories.Views;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories.Views;

public class ChuongTrinhKhungMergedRepository(DbFactory dbFactory) : AuditRepository<ChuongTrinhKhungMerged>(dbFactory), IChuongTrinhKhungMergedRepository
{
    private readonly DbFactory _dbFactory = dbFactory;

    public PaginationResponse<ChuongTrinhKhungMergedResponseDto> GetPaginatedMerged(
        PaginationRequest req, ChuongTrinhKhungFilter filter)
    {
        var baseQ = _dbFactory.DbContext.Set<ChuongTrinhKhungMerged>().AsNoTracking();

        if (filter.IdCoSoDaoTao != null) baseQ = baseQ.Where(x => x.IdCoSoDaoTao == filter.IdCoSoDaoTao);
        if (filter.IdKhoaHoc != null) baseQ = baseQ.Where(x => x.IdKhoaHoc == filter.IdKhoaHoc);
        if (filter.IdLoaiDaoTao != null) baseQ = baseQ.Where(x => x.IdLoaiDaoTao == filter.IdLoaiDaoTao);
        if (filter.IdNganhHoc != null) baseQ = baseQ.Where(x => x.IdNganhHoc == filter.IdNganhHoc);
        if (filter.IdBacDaoTao != null) baseQ = baseQ.Where(x => x.IdBacDaoTao == filter.IdBacDaoTao);
        if (filter.IdChuyenNganh != null) baseQ = baseQ.Where(x => x.IdChuyenNganh == filter.IdChuyenNganh);

        var total = baseQ.Count();

        var pageIds = baseQ
            .Skip((req.Page - 1) * req.PageSize)
            .Take(req.PageSize)
            .Select(x => x.Id)
            .ToList();

        var rows = (
            from v in DbSet.AsNoTracking()
            where pageIds.Contains(v.Id)
            join cs in _dbFactory.DbContext.Set<CoSoDaoTao>().AsNoTracking() on v.IdCoSoDaoTao equals cs.Id into csj
            from cs in csj.DefaultIfEmpty()
            join kh in _dbFactory.DbContext.Set<KhoaHoc>().AsNoTracking() on v.IdKhoaHoc equals kh.Id into Khj
            from kh in Khj.DefaultIfEmpty()
            join ld in _dbFactory.DbContext.Set<LoaiDaoTao>().AsNoTracking() on v.IdLoaiDaoTao equals ld.Id into Ldj
            from ld in Ldj.DefaultIfEmpty()
            join ng in _dbFactory.DbContext.Set<NganhHoc>().AsNoTracking() on v.IdNganhHoc equals ng.Id into Ngj
            from ng in Ngj.DefaultIfEmpty()
            join bc in _dbFactory.DbContext.Set<BacDaoTao>().AsNoTracking() on v.IdBacDaoTao equals bc.Id into Bcj
            from bc in Bcj.DefaultIfEmpty()
            join cn in _dbFactory.DbContext.Set<ChuyenNganh>().AsNoTracking() on v.IdChuyenNganh equals cn.Id into Cnj
            from cn in Cnj.DefaultIfEmpty()
            select new ChuongTrinhKhungMergedResponseDto
            {
                Id = v.Id,
                MaChuongTrinh = v.MaChuongTrinh,
                TenChuongTrinh = v.TenChuongTrinh,
                IsNienChe = v.IsNienChe,
                IdCoSoDaoTao = v.IdCoSoDaoTao,
                IsBlock = v.IsBlock,
                CoSoDaoTao = cs ?? null,
                KhoaHoc = kh ?? null,
                LoaiDaoTao = ld ?? null,
                NganhHoc = ng ?? null,
                BacDaoTao = bc ?? null,
                ChuyenNganh = cn ?? null
            }
        ).ToList();

        var orderIndex = pageIds.Select((id, idx) => new { id, idx })
                                .ToDictionary(x => x.id, x => x.idx);
        rows = [.. rows.OrderBy(r => orderIndex[r.Id])];

        return new PaginationResponse<ChuongTrinhKhungMergedResponseDto>
        {
            CurrentPage = req.Page,
            PageSize = req.PageSize,
            TotalCount = total,
            TotalPages = (int)Math.Ceiling(total / (decimal)req.PageSize),
            Result = rows
        };
    }
}
