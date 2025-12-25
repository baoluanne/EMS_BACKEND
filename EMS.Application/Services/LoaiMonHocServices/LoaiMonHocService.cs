using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LoaiMonHocServices;

public class LoaiMonHocService : BaseService<LoaiMonHoc>, ILoaiMonHocService
{
    public LoaiMonHocService(IUnitOfWork unitOfWork, ILoaiMonHocRepository loaiMonHocRepository) 
        : base(unitOfWork, loaiMonHocRepository)
    {
    }

    protected override Task UpdateEntityProperties(LoaiMonHoc existingEntity, LoaiMonHoc newEntity)
    {
        existingEntity.MaLoaiMonHoc = newEntity.MaLoaiMonHoc;
        existingEntity.TenLoaiMonHoc = newEntity.TenLoaiMonHoc;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 