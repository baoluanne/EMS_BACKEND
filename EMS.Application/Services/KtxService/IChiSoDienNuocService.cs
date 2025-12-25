using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public interface IChiSoDienNuocService : IBaseService<ChiSoDienNuoc>
    {
        Task<Result<ChiSoDienNuocPagingResponse>> GetPaginatedAsync(
            PaginationRequest request,
            Guid? toaNhaId = null,
            Guid? phongId = null,
            int? thang = null,
            int? nam = null,
            bool? daChot = null);

        ChiSoDienNuocCalculationResponse CalculateConsumption(
            double dienCu,
            double dienMoi,
            double nuocCu,
            double nuocMoi);
    }
}