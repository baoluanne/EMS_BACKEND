using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.CoSoDaoTaoServices;

public class CoSoDaoTaoService : BaseService<CoSoDaoTao>, ICoSoDaoTaoService
{
    public CoSoDaoTaoService(IUnitOfWork unitOfWork, ICoSoDaoTaoRepository coSoDaoTaoRepository) 
        : base(unitOfWork, coSoDaoTaoRepository)
    {
    }

    protected override Task UpdateEntityProperties(CoSoDaoTao existingEntity, CoSoDaoTao newEntity)
    {
        existingEntity.MaCoSo = newEntity.MaCoSo;
        existingEntity.TenCoSo = newEntity.TenCoSo;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 