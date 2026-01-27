using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public interface IPhongKtxService : IBaseService<KtxPhong>
    {
        Task<Result<List<KtxPhong>>> CreateBatchAsync(BatchCreatePhongModel model);
    }
}
