using EMS.Application.DTOs.Financial;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.FinancialModuleManagement;
using LanguageExt.Common;

namespace EMS.Application.Services.Financial
{
    public interface IChinhSachMienGiamService : IBaseService<ChinhSachMienGiam>
    {
        Task<Result<ChinhSachMienGiamDto>> GetDetailAsync(Guid id);

        Task<Result<PagedChinhSachMienGiamResult>> GetPagedAsync(int page, int pageSize, string? keyword);

        Task<Result<ChinhSachMienGiamDto>> CreateAsync(CreateChinhSachMienGiamDto dto);
        Task<Result<ChinhSachMienGiamDto>> UpdateAsync(Guid id, UpdateChinhSachMienGiamDto dto);
    }
}