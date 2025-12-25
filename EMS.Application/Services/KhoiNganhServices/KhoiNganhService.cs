using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.KhoiNganhServices;

public class KhoiNganhService : BaseService<KhoiNganh>, IKhoiNganhService
{
    public KhoiNganhService(IUnitOfWork unitOfWork, IKhoiNganhRepository khoiNganhRepository) 
        : base(unitOfWork, khoiNganhRepository)
    {
    }

    protected override Task UpdateEntityProperties(KhoiNganh existingEntity, KhoiNganh newEntity)
    {
        existingEntity.MaKhoiNganh = newEntity.MaKhoiNganh;
        existingEntity.TenKhoiNganh = newEntity.TenKhoiNganh;
        existingEntity.IsVisible = newEntity.IsVisible;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 