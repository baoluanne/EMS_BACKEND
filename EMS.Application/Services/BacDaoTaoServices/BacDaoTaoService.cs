using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.BacDaoTaoServices
{
    public class BacDaoTaoService : BaseService<BacDaoTao>, IBacDaoTaoService
    {
        public BacDaoTaoService(IUnitOfWork unitOfWork, IBacDaoTaoRepository bacDaoTaoRepository) 
            : base(unitOfWork, bacDaoTaoRepository)
        {
        }

        protected override Task UpdateEntityProperties(BacDaoTao existingEntity, BacDaoTao newEntity)
        {
            existingEntity.MaBacDaoTao = newEntity.MaBacDaoTao;
            existingEntity.TenBacDaoTao = newEntity.TenBacDaoTao;
            existingEntity.DaoTaoMonVanHoa = newEntity.DaoTaoMonVanHoa;
            existingEntity.HinhThucDaoTao = newEntity.HinhThucDaoTao;
            existingEntity.KyTuMaSinhVien = newEntity.KyTuMaSinhVien;
            existingEntity.STT = newEntity.STT;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.KyTuMaHoSoTuyenSinh = newEntity.KyTuMaHoSoTuyenSinh;
            existingEntity.TenTiengAnh = newEntity.TenTiengAnh;
            existingEntity.IsVisible = newEntity.IsVisible;
            existingEntity.TenLoaiBangCapTN = newEntity.TenLoaiBangCapTN;
            existingEntity.TenLoaiBangCapTN_ENG = newEntity.TenLoaiBangCapTN_ENG;
            existingEntity.PhongBanKyBM = newEntity.PhongBanKyBM;
            return Task.CompletedTask;
        }
    }
} 