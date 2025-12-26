using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

public class TaiSanKtxRepository(DbFactory dbFactory)
    : AuditRepository<TaiSanKtx>(dbFactory), ITaiSanKtxRepository
{
    public async Task<(List<TaiSanKtxResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(
        PaginationRequest request,
        Guid? phongKtxId = null,
        string? tinhTrang = null,
        string? searchTerm = null)
    {
        var query = DbSet.AsNoTracking()
            .Include(t => t.PhongKtx)
                .ThenInclude(p => p.ToaNha)
            .Where(t => !t.IsDeleted);

        if (phongKtxId.HasValue)
            query = query.Where(t => t.PhongKtxId == phongKtxId.Value);

        if (!string.IsNullOrWhiteSpace(tinhTrang))
            query = query.Where(t => t.TinhTrang == tinhTrang.Trim());

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var term = searchTerm.Trim().ToLower();
            query = query.Where(t =>
                t.MaTaiSan.ToLower().Contains(term) ||
                t.TenTaiSan.ToLower().Contains(term) ||
                t.GhiChu != null && t.GhiChu.ToLower().Contains(term));
        }

        var total = await query.CountAsync();

        var data = await query
            .OrderByDescending(t => t.NgayCapNhat)
            .Select(t => new TaiSanKtxResponseDto
            {
                Id = t.Id,
                MaTaiSan = t.MaTaiSan,
                TenTaiSan = t.TenTaiSan,
                TinhTrang = t.TinhTrang,
                GiaTri = t.GiaTri,
                GhiChu = t.GhiChu,
                PhongKtxId = t.PhongKtxId,
                MaPhong = t.PhongKtx != null ? t.PhongKtx.MaPhong : "",
                TenToaNha = t.PhongKtx.ToaNha != null ? t.PhongKtx.ToaNha.TenToaNha ?? "" : ""
            })
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return (data, total);
    }
}