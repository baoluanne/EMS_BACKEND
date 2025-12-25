using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.XetLLHB_QuyCheTC_Services;

public class XetLLHB_QuyCheTC_Service : BaseService<XetLLHB_QuyCheTC>, IXetLLHB_QuyCheTC_Service
{
    public XetLLHB_QuyCheTC_Service(IUnitOfWork unitOfWork, IXetLLHB_QuyCheTC_Repository xetLLHB_QuyCheTC_Repository) 
        : base(unitOfWork, xetLLHB_QuyCheTC_Repository)
    {
    }

    protected override Task UpdateEntityProperties(XetLLHB_QuyCheTC existingEntity, XetLLHB_QuyCheTC newEntity)
    {
        existingEntity.IdQuyCheHocVu = newEntity.IdQuyCheHocVu;
        existingEntity.NamThu = newEntity.NamThu;
        existingEntity.TCTichLuyTu = newEntity.TCTichLuyTu;
        existingEntity.TCTichLuyDen = newEntity.TCTichLuyDen;
        existingEntity.DiemTBCTichLuy = newEntity.DiemTBCTichLuy;
        
        return Task.CompletedTask;
    }
} 