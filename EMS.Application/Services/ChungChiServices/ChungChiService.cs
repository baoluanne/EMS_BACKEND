using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.ChungChiServices
{
    public class ChungChiService : BaseService<ChungChi>, IChungChiService
    {
        public ChungChiService(IUnitOfWork unitOfWork, IChungChiRepository chungChiRepository) 
            : base(unitOfWork, chungChiRepository)
        {
        }

        protected override Task UpdateEntityProperties(ChungChi existingEntity, ChungChi newEntity)
        {
            existingEntity.TenLoaiChungChi = newEntity.TenLoaiChungChi;
            existingEntity.KyHieu = newEntity.KyHieu;
            existingEntity.GiaTri = newEntity.GiaTri;
            existingEntity.HocPhi = newEntity.HocPhi;
            existingEntity.LePhiThi = newEntity.LePhiThi;
            existingEntity.ThoiHan = newEntity.ThoiHan;
            existingEntity.DiemQuyDinh = newEntity.DiemQuyDinh;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IdLoaiChungChi = newEntity.IdLoaiChungChi;

            return Task.CompletedTask;
        }
    }
} 