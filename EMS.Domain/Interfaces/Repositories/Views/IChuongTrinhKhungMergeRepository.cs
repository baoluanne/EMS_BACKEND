using EMS.Domain.Dtos;
using EMS.Domain.Entities.Views;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Models;

namespace EMS.Domain.Interfaces.Repositories.Views;

public interface IChuongTrinhKhungMergedRepository : IAuditRepository<ChuongTrinhKhungMerged>
{
    PaginationResponse<ChuongTrinhKhungMergedResponseDto> GetPaginatedMerged(PaginationRequest req, ChuongTrinhKhungFilter filter);
}
