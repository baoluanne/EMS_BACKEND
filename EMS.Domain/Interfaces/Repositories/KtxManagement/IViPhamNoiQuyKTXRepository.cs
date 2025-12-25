using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;

namespace EMS.Domain.Interfaces.Repositories.KtxManagement
{
    public interface IViPhamNoiQuyKTXRepository : IAuditRepository<ViPhamNoiQuyKTX>
    {
        Task<(List<ViPhamNoiQuyKtxResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(ViPhamFilterRequest request);
    }
}