using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories.KtxManagement;

public class HoaDonKtxRepository(DbFactory dbFactory)
    : AuditRepository<HoaDonKtx>(dbFactory), IHoaDonKtxRepository
{
    public async Task<(List<HoaDonKtxResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(
        PaginationRequest request,
        Guid? phongKtxId = null,
        int? thang = null,
        int? nam = null,
        string? trangThai = null)
    {
        var query = DbSet.AsNoTracking()
            .Include(h => h.PhongKtx).ThenInclude(p => p.ToaNha)
            .Include(h => h.ChiSoDienNuoc)
            .Where(h => !h.IsDeleted);

        if (phongKtxId.HasValue)
            query = query.Where(h => h.PhongKtxId == phongKtxId.Value);

        if (thang.HasValue)
            query = query.Where(h => h.Thang == thang.Value);

        if (nam.HasValue)
            query = query.Where(h => h.Nam == nam.Value);

        if (!string.IsNullOrWhiteSpace(trangThai))
            query = query.Where(h => h.TrangThai == trangThai);

        var total = await query.CountAsync();

        var data = await query
            .OrderByDescending(h => h.Nam)
            .ThenByDescending(h => h.Thang)
            .Select(h => new HoaDonKtxResponseDto
            {
                Id = h.Id,
                Thang = h.Thang,
                Nam = h.Nam,
                TienDien = h.TienDien,
                TienNuoc = h.TienNuoc,
                TongTien = h.TongTien,
                TrangThai = h.TrangThai,
                NgayThanhToan = h.NgayThanhToan,
                GhiChu = h.GhiChu,
                PhongKtxId = h.PhongKtxId,
                MaPhong = h.PhongKtx.MaPhong ?? "",
                TenToaNha = h.PhongKtx.ToaNha.TenToaNha ?? "",
                ChiSoDienNuocId = h.ChiSoDienNuocId
            })
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return (data, total);
    }
}