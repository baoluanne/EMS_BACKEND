using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LoaiTietServices;

public class LoaiTietService : BaseService<LoaiTiet>, ILoaiTietService
{
    public LoaiTietService(IUnitOfWork unitOfWork, ILoaiTietRepository loaiTietRepository) 
        : base(unitOfWork, loaiTietRepository)
    {
    }

    protected override Task UpdateEntityProperties(LoaiTiet existingEntity, LoaiTiet newEntity)
    {
        existingEntity.MaLoaiTiet = newEntity.MaLoaiTiet;
        existingEntity.TenLoaiTiet = newEntity.TenLoaiTiet;
        existingEntity.HeSo = newEntity.HeSo;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 