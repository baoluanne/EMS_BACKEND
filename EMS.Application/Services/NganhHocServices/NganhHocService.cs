using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.NganhHocServices;

public class NganhHocService : BaseService<NganhHoc>, INganhHocService
{
    public NganhHocService(IUnitOfWork unitOfWork, INganhHocRepository nganhHocRepository) 
        : base(unitOfWork, nganhHocRepository)
    {
    }

    protected override Task UpdateEntityProperties(NganhHoc existingEntity, NganhHoc newEntity)
    {
        existingEntity.MaNganhHoc = newEntity.MaNganhHoc;
        existingEntity.TenNganhHoc = newEntity.TenNganhHoc;
        existingEntity.TenTiengAnh = newEntity.TenTiengAnh;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 