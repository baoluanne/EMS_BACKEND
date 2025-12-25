using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.KieuLamTronServices;

public class KieuLamTronService : BaseService<KieuLamTron>, IKieuLamTronService
{
    public KieuLamTronService(IUnitOfWork unitOfWork, IKieuLamTronRepository kieuLamTronRepository) 
        : base(unitOfWork, kieuLamTronRepository)
    {
    }

    protected override Task UpdateEntityProperties(KieuLamTron existingEntity, KieuLamTron newEntity)
    {
        existingEntity.MaKieuLamTron = newEntity.MaKieuLamTron;
        existingEntity.TenKieuLamTron = newEntity.TenKieuLamTron;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 