using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;

namespace EMS.Domain.Interfaces.Repositories.KtxManagement
{
    public interface IChiSoDienNuocRepository : IAuditRepository<ChiSoDienNuoc>
    {
        Task<(List<ChiSoDienNuocResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(
            PaginationRequest request,
            Guid? toaNhaId = null,
            Guid? phongId = null,
            int? thang = null,
            int? nam = null,
            bool? daChot = null);
    }
}