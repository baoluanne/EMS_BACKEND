using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.KhoaHocServices;

public class KhoaHocService : BaseService<KhoaHoc>, IKhoaHocService
{
    public KhoaHocService(IUnitOfWork unitOfWork, IKhoaHocRepository khoaHocRepository) 
        : base(unitOfWork, khoaHocRepository)
    {
    }

    protected override Task UpdateEntityProperties(KhoaHoc existingEntity, KhoaHoc newEntity)
    {
        existingEntity.TenKhoaHoc = newEntity.TenKhoaHoc;
        existingEntity.Nam = newEntity.Nam;
        existingEntity.CachViet = newEntity.CachViet;
        existingEntity.GhiChu = newEntity.GhiChu;
        existingEntity.IsVisible = newEntity.IsVisible;
        
        return Task.CompletedTask;
    }
} 