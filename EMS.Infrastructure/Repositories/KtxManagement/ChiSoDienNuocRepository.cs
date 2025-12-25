using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories.KtxManagement
{
    public class ChiSoDienNuocRepository(DbFactory dbFactory)
        : AuditRepository<ChiSoDienNuoc>(dbFactory), IChiSoDienNuocRepository
    {
        public async Task<(List<ChiSoDienNuocResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(
            PaginationRequest request,
            Guid? toaNhaId = null,
            Guid? phongId = null,
            int? thang = null,
            int? nam = null,
            bool? daChot = null)
        {
            var query = DbSet.AsQueryable()
                .Include(e => e.PhongKtx!)
                .ThenInclude(p => p.ToaNha)
                .Where(e => !e.IsDeleted);

            // Apply filters
            if (toaNhaId.HasValue)
                query = query.Where(e => e.PhongKtx!.ToaNhaId == toaNhaId.Value);

            if (phongId.HasValue)
                query = query.Where(e => e.PhongKtxId == phongId.Value);

            if (thang.HasValue)
                query = query.Where(e => e.Thang == thang.Value);

            if (nam.HasValue)
                query = query.Where(e => e.Nam == nam.Value);

            if (daChot.HasValue)
                query = query.Where(e => e.DaChot == daChot.Value);

            var total = await query.CountAsync();
            int skip = (request.Page - 1) * request.PageSize;

            var data = await query
                .OrderByDescending(x => x.Nam)
                .ThenByDescending(x => x.Thang)
                .ThenBy(x => x.PhongKtx!.MaPhong)
                .Skip(skip)
                .Take(request.PageSize)
                .Select(e => new ChiSoDienNuocResponseDto
                {
                    Id = e.Id,
                    PhongKtxId = e.PhongKtxId,
                    MaPhong = e.PhongKtx!.MaPhong,
                    TenToaNha = e.PhongKtx!.ToaNha!.TenToaNha ?? string.Empty,
                    Thang = e.Thang,
                    Nam = e.Nam,
                    DienCu = e.DienCu,
                    DienMoi = e.DienMoi,
                    NuocCu = e.NuocCu,
                    NuocMoi = e.NuocMoi,
                    DaChot = e.DaChot
                })
                .ToListAsync();

            return (data, total);
        }
    }
}