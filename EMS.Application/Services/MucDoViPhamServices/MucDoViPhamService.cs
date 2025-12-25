using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.MucDoViPhamServices
{
    public class MucDoViPhamService : BaseService<MucDoViPham>, IMucDoViPhamService
    {
        public MucDoViPhamService(IUnitOfWork unitOfWork, IMucDoViPhamRepository mucDoViPhamRepository) 
            : base(unitOfWork, mucDoViPhamRepository)
        {
        }

        protected override Task UpdateEntityProperties(MucDoViPham existingEntity, MucDoViPham newEntity)
        {
            existingEntity.MaMucDoViPham = newEntity.MaMucDoViPham;
            existingEntity.TenMucDoViPham = newEntity.TenMucDoViPham;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IsActive = newEntity.IsActive;
            return Task.CompletedTask;
        }
    }
} 