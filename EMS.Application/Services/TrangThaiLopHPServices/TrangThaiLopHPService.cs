using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.TrangThaiLopHPServices;

public class TrangThaiLopHPService : BaseService<TrangThaiLopHP>, ITrangThaiLopHPService
{
    public TrangThaiLopHPService(IUnitOfWork unitOfWork, ITrangThaiLopHPRepository trangThaiLopHPRepository) 
        : base(unitOfWork, trangThaiLopHPRepository)
    {
    }

    protected override Task UpdateEntityProperties(TrangThaiLopHP existingEntity, TrangThaiLopHP newEntity)
    {
        existingEntity.MaTrangThaiLop = newEntity.MaTrangThaiLop;
        existingEntity.TenTrangThaiLop = newEntity.TenTrangThaiLop;
        existingEntity.STT = newEntity.STT;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 