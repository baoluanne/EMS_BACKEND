using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LoaiChungChiServices;

public class LoaiChungChiService : BaseService<LoaiChungChi>, ILoaiChungChiService
{
    public LoaiChungChiService(IUnitOfWork unitOfWork, ILoaiChungChiRepository loaiChungChiRepository) 
        : base(unitOfWork, loaiChungChiRepository)
    {
    }

    protected override Task UpdateEntityProperties(LoaiChungChi existingEntity, LoaiChungChi newEntity)
    {
        existingEntity.MaLoaiChungChi = newEntity.MaLoaiChungChi;
        existingEntity.TenLoaiChungChi = newEntity.TenLoaiChungChi;
        existingEntity.STT = newEntity.STT;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 