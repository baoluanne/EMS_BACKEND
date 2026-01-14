using EMS.Application.DTOs.KtxManagement;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories.KtxManagement
{
    public class GiuongKtxRepository(DbFactory dbFactory)
        : AuditRepository<KtxGiuong>(dbFactory), IGiuongKtxRepository
    {
        public async Task<(List<GiuongKtxResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(
            PaginationRequest request,
            string? maGiuong = null,
            string? phongKtxId = null,
            string? trangThai = null)
        {
            var query = DbSet
                .AsNoTracking()
                .Where(g => !g.IsDeleted && !g.PhongKtx.IsDeleted && !g.PhongKtx.ToaNha.IsDeleted);

            if (!string.IsNullOrEmpty(maGiuong))
            {
                query = query.Where(g => g.MaGiuong.Contains(maGiuong));
            }

            if (!string.IsNullOrEmpty(trangThai))
            {
                query = query.Where(g => g.TrangThai == trangThai);
            }

            if (!string.IsNullOrEmpty(phongKtxId) && Guid.TryParse(phongKtxId, out Guid pId))
            {
                query = query.Where(g => g.PhongKtxId == pId);
            }

            var total = await query.CountAsync();

            var data = await query
                .Include(g => g.PhongKtx)
                    .ThenInclude(p => p.ToaNha)
                .Include(g => g.SinhVien)
                .Select(g => new GiuongKtxResponseDto
                {
                    Id = g.Id,
                    MaGiuong = g.MaGiuong ?? "",
                    PhongKtxId = g.PhongKtxId,
                    MaPhong = g.PhongKtx.MaPhong ?? "",
                    TenToaNha = g.PhongKtx.ToaNha != null ? g.PhongKtx.ToaNha.TenToaNha ?? "" : "",
                    SinhVienId = g.SinhVienId,
                    TenSinhVien = g.SinhVien != null
                        ? $"{g.SinhVien.HoDem} {g.SinhVien.Ten}".Trim()
                        : null,
                    TrangThai = g.TrangThai ?? "TRONG"
                })
                .OrderBy(g => g.TenToaNha)
                .ThenBy(g => g.MaPhong)
                .ThenBy(g => g.MaGiuong)
                .Take(request.PageSize)
                .ToListAsync();

            return (data, total);
        }
    }
}