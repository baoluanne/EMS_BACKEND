using EMS.Application.DTOs.KtxManagement;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories.KtxManagement
{
    public class ToaNhaKtxRepository(DbFactory dbFactory)
        : AuditRepository<ToaNhaKtx>(dbFactory), IToaNhaKtxRepository
    {
        public async Task<(List<ToaNhaKtxResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(PaginationRequest request)
        {
            var query = DbSet
                .AsNoTracking()
                .Where(t => !t.IsDeleted)
                .Include(t => t.PhongKtxs)
                .Select(t => new ToaNhaKtxResponseDto
                {
                    Id = t.Id,
                    TenToaNha = t.TenToaNha ?? "",
                    LoaiToaNha = t.LoaiToaNha,
                    SoPhong = t.PhongKtxs.Count(p => !p.IsDeleted)
                });

            var total = await query.CountAsync();

            var data = await query
                .OrderBy(t => t.TenToaNha)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return (data, total);
        }
    }
}