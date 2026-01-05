using System.Linq.Expressions;
using EMS.Application.DTOs.KtxManagement;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Models;

public interface IChiSoDienNuocRepository : IAuditRepository<ChiSoDienNuoc>
{
    Task<(List<ChiSoDienNuocResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(
        PaginationRequest request,
        Expression<Func<ChiSoDienNuoc, bool>> predicate);
}