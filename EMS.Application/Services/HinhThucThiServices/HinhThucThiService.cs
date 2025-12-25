using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.HinhThucThiServices
{
    public class HinhThucThiService : BaseService<HinhThucThi>, IHinhThucThiService
    {
        public HinhThucThiService(IUnitOfWork unitOfWork, IHinhThucThiRepository hinhThucThiRepository) 
            : base(unitOfWork, hinhThucThiRepository)
        {
        }

        protected override Task UpdateEntityProperties(HinhThucThi existingEntity, HinhThucThi newEntity)
        {
            existingEntity.MaHinhThucThi = newEntity.MaHinhThucThi;
            existingEntity.TenHinhThucThi = newEntity.TenHinhThucThi;
            existingEntity.STT = newEntity.STT;
            existingEntity.HeSoChamThi = newEntity.HeSoChamThi;
            existingEntity.SoGiangVien = newEntity.SoGiangVien;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IdBieuMauDanhSachDuThi = newEntity.IdBieuMauDanhSachDuThi;
            return Task.CompletedTask;
        }
    }
} 