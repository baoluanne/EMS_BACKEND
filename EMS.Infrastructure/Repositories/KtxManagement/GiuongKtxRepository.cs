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
        : AuditRepository<GiuongKtx>(dbFactory), IGiuongKtxRepository
    {
        public async Task<(List<GiuongKtxResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(PaginationRequest request)
        {
            var query = DbSet
                .AsNoTracking()
                .Where(g => !g.IsDeleted && !g.PhongKtx.IsDeleted && !g.PhongKtx.ToaNha.IsDeleted)
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
                    TrangThai = g.TrangThai
                });

            var total = await query.CountAsync();

            var data = await query
                .OrderBy(g => g.TenToaNha)
                .ThenBy(g => g.MaPhong)
                .ThenBy(g => g.MaGiuong)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return (data, total);
        }
    }
}