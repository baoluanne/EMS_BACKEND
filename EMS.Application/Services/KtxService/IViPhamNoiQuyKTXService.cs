using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public interface IViPhamNoiQuyKTXService : IBaseService<KtxViPhamNoiQuy>
    {
        Task<Result<Guid>> CreateViPhamAsync(CreateViPhamNoiQuyKtxDto dto);
        Task<Result<ViPhamNoiQuyKtxPagingResponse>> GetPaginatedAsync(ViPhamFilterRequest request);
        Task<Result<bool>> UpdateViPhamAsync(UpdateViPhamNoiQuyKtxDto dto);
    }
}