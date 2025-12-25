using EMS.Application.Services.Base;
using EMS.Application.Services.TinhThanhServices;
using EMS.Application.Services.ToBoMonServices;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.PhuongXaServices;

public class PhuongXaService : BaseService<PhuongXa>, IPhuongXaService
{
    public PhuongXaService(IUnitOfWork unitOfWork, IPhuongXaRepository phuongXaRepository) 
        : base(unitOfWork, phuongXaRepository)
    {
    }

    protected override Task UpdateEntityProperties(PhuongXa existingEntity, PhuongXa newEntity) 
    {
        existingEntity.MaPhuongXa = newEntity.MaPhuongXa;
        existingEntity.TenPhuongXa = newEntity.TenPhuongXa;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 