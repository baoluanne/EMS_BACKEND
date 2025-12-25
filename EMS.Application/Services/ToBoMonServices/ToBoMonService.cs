using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.ToBoMonServices;

public class ToBoMonService : BaseService<ToBoMon>, IToBoMonService
{
    public ToBoMonService(IUnitOfWork unitOfWork, IToBoMonRepository toBoMonRepository) 
        : base(unitOfWork, toBoMonRepository)
    {
    }

    protected override Task UpdateEntityProperties(ToBoMon existingEntity, ToBoMon newEntity)
    {
        existingEntity.MaToBoMon = newEntity.MaToBoMon;
        existingEntity.TenToBoMon = newEntity.TenToBoMon;
        existingEntity.IdKhoa = newEntity.IdKhoa;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 