using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.HinhThucXuLyVPQCThiServices
{
    public class HinhThucXuLyVPQCThiService : BaseService<HinhThucXuLyVPQCThi>, IHinhThucXuLyVPQCThiService
    {
        public HinhThucXuLyVPQCThiService(IUnitOfWork unitOfWork, IHinhThucXuLyVPQCThiRepository hinhThucXuLyVPQCThiRepository) 
            : base(unitOfWork, hinhThucXuLyVPQCThiRepository)
        {
        }

        protected override Task UpdateEntityProperties(HinhThucXuLyVPQCThi existingEntity, HinhThucXuLyVPQCThi newEntity)
        {
            existingEntity.MaHinhThucXL = newEntity.MaHinhThucXL;
            existingEntity.TenHinhThucXL = newEntity.TenHinhThucXL;
            existingEntity.PhanTramDiemTru = newEntity.PhanTramDiemTru;
            existingEntity.DiemTruRL = newEntity.DiemTruRL;
            existingEntity.IdMucDo = newEntity.IdMucDo;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
} 