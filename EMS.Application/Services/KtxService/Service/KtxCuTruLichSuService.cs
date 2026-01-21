using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;

namespace EMS.Application.Services.KtxService.Service
{
    public class KtxCuTruLichSuService : BaseService<KtxCuTruLichSu>, IKtxCuTruLichSuService
    {
        private readonly IKtxCuTruLichSuRepository _repository;

        public KtxCuTruLichSuService(IUnitOfWork unitOfWork, IKtxCuTruLichSuRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        protected override Task UpdateEntityProperties(KtxCuTruLichSu existingEntity, KtxCuTruLichSu newEntity)
        {
            existingEntity.CuTruId = newEntity.CuTruId;
            existingEntity.SinhVienId = newEntity.SinhVienId;
            existingEntity.DonKtxId = newEntity.DonKtxId;
            existingEntity.LoaiDon = newEntity.LoaiDon;
            existingEntity.PhongCuId = newEntity.PhongCuId;
            existingEntity.GiuongCuId = newEntity.GiuongCuId;
            existingEntity.PhongMoiId = newEntity.PhongMoiId;
            existingEntity.GiuongMoiId = newEntity.GiuongMoiId;
            existingEntity.IdHocKy = newEntity.IdHocKy;
            existingEntity.NgayBatDau = newEntity.NgayBatDau;
            existingEntity.NgayRoiDuKien = newEntity.NgayRoiDuKien;
            existingEntity.NgayRoiThucTe = newEntity.NgayRoiThucTe;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.NgayGhiLichSu = newEntity.NgayGhiLichSu;
            return Task.CompletedTask;
        }
    }
}