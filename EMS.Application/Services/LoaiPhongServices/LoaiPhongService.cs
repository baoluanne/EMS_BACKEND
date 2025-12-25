using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LoaiPhongServices
{
    public class LoaiPhongService : BaseService<LoaiPhong>, ILoaiPhongService
    {
        public LoaiPhongService(IUnitOfWork unitOfWork, ILoaiPhongRepository loaiPhongRepository) 
            : base(unitOfWork, loaiPhongRepository)
        {
        }

        protected override Task UpdateEntityProperties(LoaiPhong existingEntity, LoaiPhong newEntity)
        {
            existingEntity.MaLoaiPhong = newEntity.MaLoaiPhong;
            existingEntity.TenLoaiPhong = newEntity.TenLoaiPhong;
            existingEntity.GhiChu = newEntity.GhiChu;

            return Task.CompletedTask;
        }
    }
} 