using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.KhoiKienThucServices;

public class KhoiKienThucService : BaseService<KhoiKienThuc>, IKhoiKienThucService
{
    public KhoiKienThucService(IUnitOfWork unitOfWork, IKhoiKienThucRepository khoiKienThucRepository) 
        : base(unitOfWork, khoiKienThucRepository)
    {
    }

    protected override Task UpdateEntityProperties(KhoiKienThuc existingEntity, KhoiKienThuc newEntity)
    {
        existingEntity.MaKhoiKienThuc = newEntity.MaKhoiKienThuc;
        existingEntity.TenKhoiKienThuc = newEntity.TenKhoiKienThuc;
        existingEntity.STT = newEntity.STT;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 