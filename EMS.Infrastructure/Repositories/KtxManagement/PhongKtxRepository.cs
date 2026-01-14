using EMS.Application.DTOs.KtxManagement;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories.KtxManagement
{
    public class PhongKtxRepository(DbFactory dbFactory)
        : AuditRepository<KtxPhong>(dbFactory), IPhongKtxRepository
    {
        public async Task<(List<PhongKtxResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(
            PaginationRequest request,
            string? maPhong = null,
            string? toaNhaId = null,
            string? trangThai = null)
        {
            var query = DbSet.AsNoTracking()
                .Include(i => i.ToaNha)
                .Where(p => !p.IsDeleted);

            if (!string.IsNullOrWhiteSpace(maPhong))
            {
                var search = maPhong.Trim().ToLower();
                query = query.Where(p => p.MaPhong.ToLower().Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(toaNhaId) && Guid.TryParse(toaNhaId, out var toaNhaGuid))
            {
                query = query.Where(p => p.ToaNhaId == toaNhaGuid);
            }

            if (!string.IsNullOrWhiteSpace(trangThai))
            {
                query = query.Where(p => p.TrangThai == trangThai);
            }

            var total = await query.CountAsync();

            var data = await query
                .OrderBy(p => p.ToaNha != null ? p.ToaNha.TenToaNha : "")
                .ThenBy(p => p.MaPhong)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new PhongKtxResponseDto
                {
                    Id = p.Id.ToString(),
                    MaPhong = p.MaPhong,
                    TenToaNha = p.ToaNha != null ? p.ToaNha.TenToaNha ?? "" : "Tòa nhà đã xóa",
                    ToaNhaId = p.ToaNhaId.ToString(),
                    SoLuongGiuong = p.SoLuongGiuong,
                    SoLuongDaO = p.SoLuongDaO,
                    TrangThai = p.TrangThai,
                    GiaPhong = p.GiaPhong,
                })
                .ToListAsync();

            return (data, total);
        }
    }
}