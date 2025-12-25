using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LoaiChucVuServices
{
    public class LoaiChucVuService : BaseService<LoaiChucVu>, ILoaiChucVuService
    {
        public LoaiChucVuService(IUnitOfWork unitOfWork, ILoaiChucVuRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(LoaiChucVu existingEntity, LoaiChucVu newEntity)
        {
            existingEntity.MaLoaiChucVu = newEntity.MaLoaiChucVu;
            existingEntity.TenLoaiChucVu = newEntity.TenLoaiChucVu;
            existingEntity.STT = newEntity.STT;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }
        
        // Implement custom methods if needed
    }
}
