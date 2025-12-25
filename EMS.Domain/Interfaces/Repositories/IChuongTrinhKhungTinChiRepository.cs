using System.Linq.Expressions;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Models;
using EMS.Domain.Dtos;

namespace EMS.Domain.Interfaces.Repositories
{
    public interface IChuongTrinhKhungTinChiRepository : IAuditRepository<ChuongTrinhKhungTinChi>
    {
        // Add custom methods here if needed
        PaginationResponse<ChuongTrinhKhungTinChiResponseDto> GetPaginatedDtoResponse(
            PaginationRequest request,
            Expression<Func<ChuongTrinhKhungTinChi, bool>>? filters,
            Func<IQueryable<ChuongTrinhKhungTinChi>, IQueryable<ChuongTrinhKhungTinChi>>? include);
    }
} 