using EMS.Application.Services.Base;
using EMS.Application.Services.KhoaServices;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services;

public class KhoaService : BaseService<Khoa>, IKhoaService
{
    public KhoaService(IUnitOfWork unitOfWork, IKhoaRepository khoaRepository) 
        : base(unitOfWork, khoaRepository)
    {
    }

    protected override Task UpdateEntityProperties(Khoa existingEntity, Khoa newEntity)
    {
        existingEntity.MaKhoa = newEntity.MaKhoa;
        existingEntity.TenKhoa = newEntity.TenKhoa;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
}