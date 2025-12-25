using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.TrangThaiXetQuyUocServices;

public class TrangThaiXetQuyUocService : BaseService<TrangThaiXetQuyUoc>, ITrangThaiXetQuyUocService
{
    public TrangThaiXetQuyUocService(IUnitOfWork unitOfWork, ITrangThaiXetQuyUocRepository trangThaiXetQuyUocRepository) 
        : base(unitOfWork, trangThaiXetQuyUocRepository)
    {
    }

    protected override Task UpdateEntityProperties(TrangThaiXetQuyUoc existingEntity, TrangThaiXetQuyUoc newEntity)
    {
        existingEntity.MaTrangThaiXetQuyUoc = newEntity.MaTrangThaiXetQuyUoc;
        existingEntity.TenTrangThaiXetQuyUoc = newEntity.TenTrangThaiXetQuyUoc;
        existingEntity.STT = newEntity.STT;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 