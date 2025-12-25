using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LoaiHinhGiangDayServices
{
    public class LoaiHinhGiangDayService : BaseService<LoaiHinhGiangDay>, ILoaiHinhGiangDayService
    {
        public LoaiHinhGiangDayService(IUnitOfWork unitOfWork, ILoaiHinhGiangDayRepository loaiHinhGiangDayRepository) 
            : base(unitOfWork, loaiHinhGiangDayRepository)
        {
        }

        protected override Task UpdateEntityProperties(LoaiHinhGiangDay existingEntity, LoaiHinhGiangDay newEntity)
        {
            existingEntity.MaLoaiHinhGiangDay = newEntity.MaLoaiHinhGiangDay;
            existingEntity.TenLoaiHinhGiangDay = newEntity.TenLoaiHinhGiangDay;
            existingEntity.STT = newEntity.STT;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
} 