using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DiaDiemPhongServices
{
    public class DiaDiemPhongService : BaseService<DiaDiemPhong>, IDiaDiemPhongService
    {
        public DiaDiemPhongService(IUnitOfWork unitOfWork, IDiaDiemPhongRepository diaDiemPhongRepository) 
            : base(unitOfWork, diaDiemPhongRepository)
        {
        }

        protected override Task UpdateEntityProperties(DiaDiemPhong existingEntity, DiaDiemPhong newEntity)
        {
            existingEntity.MaDDPhong = newEntity.MaDDPhong;
            existingEntity.TenNhomDDPhong = newEntity.TenNhomDDPhong;
            existingEntity.DiaChi = newEntity.DiaChi;
            existingEntity.IdCoSoDaoTao = newEntity.IdCoSoDaoTao;
            existingEntity.DiaDiem = newEntity.DiaDiem;
            existingEntity.BanKinh = newEntity.BanKinh;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.DayNha = newEntity.DayNha;
            return Task.CompletedTask;
        }
    }
} 