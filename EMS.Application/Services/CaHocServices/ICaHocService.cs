using EMS.Application.Services.Base;
using EMS.Domain.Entities;

namespace EMS.Application.Services.CaHocServices
{
    public interface ICaHocService : IBaseService<CaHoc>
    {
        // Add custom service methods if needed
        // Task<ImportResultResponse<CaHocImportDto>> ImportAsync(byte[] fileBytes);
    }
}