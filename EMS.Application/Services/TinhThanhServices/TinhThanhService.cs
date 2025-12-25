using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.TinhThanhServices;

public class TinhThanhService : BaseService<TinhThanh>, ITinhThanhService
{
    public TinhThanhService(IUnitOfWork unitOfWork, ITinhThanhRepository tinhThanhRepository) 
        : base(unitOfWork, tinhThanhRepository)
    {
    }

    protected override Task UpdateEntityProperties(TinhThanh existingEntity, TinhThanh newEntity)
    {
        existingEntity.MaTinhThanh = newEntity.MaTinhThanh;
        existingEntity.TenTinhThanh = newEntity.TenTinhThanh;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 