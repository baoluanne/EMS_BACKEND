using EMS.Application.DTOs.Financial;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.FinancialModuleManagement;
using LanguageExt.Common;

namespace EMS.Application.Services.Financial
{
    public interface IMienGiamService : IBaseService<MienGiamSinhVien>
    {
        Task<Result<MienGiamPagedResult>> GetPagedCustomAsync(MienGiamFilterDto filter);
        Task<Result<Guid>> ApplyAsync(ApplyMienGiamDto dto);
        Task<Result<bool>> ApproveAsync(ApprovalMienGiamDto dto);
    }
}