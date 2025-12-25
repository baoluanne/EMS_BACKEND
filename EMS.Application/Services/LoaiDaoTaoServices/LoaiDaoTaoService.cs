using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LoaiDaoTaoServices
{
    public class LoaiDaoTaoService : BaseService<LoaiDaoTao>, ILoaiDaoTaoService
    {
        public LoaiDaoTaoService(IUnitOfWork unitOfWork, ILoaiDaoTaoRepository loaiDaoTaoRepository) 
            : base(unitOfWork, loaiDaoTaoRepository)
        {
        }

        protected override Task UpdateEntityProperties(LoaiDaoTao existingEntity, LoaiDaoTao newEntity)
        {
            existingEntity.MaLoaiDaoTao = newEntity.MaLoaiDaoTao;
            existingEntity.TenLoaiDaoTao = newEntity.TenLoaiDaoTao;
            existingEntity.TenTiengAnh = newEntity.TenTiengAnh;
            existingEntity.NoiDung = newEntity.NoiDung;
            existingEntity.SoThuTu = newEntity.SoThuTu;
            existingEntity.HienThiGhiChu = newEntity.HienThiGhiChu;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
} 