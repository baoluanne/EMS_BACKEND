using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DayNhaServices
{
    public class DayNhaService : BaseService<DayNha>, IDayNhaService
    {
        public DayNhaService(IUnitOfWork unitOfWork, IDayNhaRepository dayNhaRepository) 
            : base(unitOfWork, dayNhaRepository)
        {
        }

        protected override Task UpdateEntityProperties(DayNha existingEntity, DayNha newEntity)
        {
            existingEntity.MaDayNha = newEntity.MaDayNha;
            existingEntity.TenDayNha = newEntity.TenDayNha;
            existingEntity.SoTang = newEntity.SoTang;
            existingEntity.SoPhong = newEntity.SoPhong;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IdDiaDiemPhong = newEntity.IdDiaDiemPhong;
            existingEntity.PhongHoc = newEntity.PhongHoc;
            return Task.CompletedTask;
        }
    }
}