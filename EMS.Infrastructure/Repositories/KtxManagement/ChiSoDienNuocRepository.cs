using System.Linq.Expressions;
using EMS.Application.DTOs.KtxManagement;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;


public class ChiSoDienNuocRepository(DbFactory dbFactory)
    : AuditRepository<ChiSoDienNuoc>(dbFactory), IChiSoDienNuocRepository
{
    public async Task<(List<ChiSoDienNuocResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(
        PaginationRequest request,
        Expression<Func<ChiSoDienNuoc, bool>> predicate)
    {
        var query = DbSet
            .AsNoTracking()
            .Where(predicate)
            .Include(q => q.PhongKtx!)
            .ThenInclude(p => p.ToaNha);

        var total = await query.CountAsync();

        var data = await query
            .OrderByDescending(q => q.Nam)
            .ThenByDescending(q => q.Thang)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(q => new ChiSoDienNuocResponseDto
            {
                Id = q.Id,
                TenToaNha = q.PhongKtx!.ToaNha!.TenToaNha,
                MaPhong = q.PhongKtx!.MaPhong,
                ThangNam = $"Tháng {q.Thang}/{q.Nam}",
                DienCu = q.DienCu,
                DienMoi = q.DienMoi,
                TieuThuDien = q.DienMoi - q.DienCu,
                NuocCu = q.NuocCu,
                NuocMoi = q.NuocMoi,
                TieuThuNuoc = q.NuocMoi - q.NuocCu,
                DaChot = q.DaChot
            })
            .ToListAsync();

        return (data, total);
    }
}