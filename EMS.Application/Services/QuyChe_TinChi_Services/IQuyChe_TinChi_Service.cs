using EMS.Application.Services.Base;
using EMS.Domain.Entities;

namespace EMS.Application.Services.QuyChe_TinChi_Services
{
    public interface IQuyChe_TinChi_Service : IBaseService<QuyChe_TinChi>
    {
        Task<QuyChe_TinChi?> GetByQuyCheHocVuIdAsync(Guid quyCheHocVuId);
    }
} 