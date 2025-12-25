using EMS.Application.Services.Base;
using EMS.Domain.Entities;

namespace EMS.Application.Services.QuyChe_NienChe_Services
{
    public interface IQuyChe_NienChe_Service : IBaseService<QuyChe_NienChe>
    {
        Task<QuyChe_NienChe?> GetByQuyCheHocVuIdAsync(Guid quyCheHocVuId);
    }
} 