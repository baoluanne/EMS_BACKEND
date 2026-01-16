using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService;

public interface IToaNhaKtxService : IBaseService<KTXToaNha>
{
    Task<Result<KTXToaNha>> GetToaNhaStructureAsync(Guid id);
}