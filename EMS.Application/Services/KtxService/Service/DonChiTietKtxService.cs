using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;

namespace EMS.Application.Services.KtxService.Service
{
    public class DonChiTietKtxService : BaseService<KtxDonChiTiet>, IDonChiTietKtxService
    {
        private readonly IDonChiTietKtxRepository _repository;

        public DonChiTietKtxService(IUnitOfWork unitOfWork, IDonChiTietKtxRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        protected override Task UpdateEntityProperties(KtxDonChiTiet existingEntity, KtxDonChiTiet newEntity)
        {
            existingEntity.DonKtxId = newEntity.DonKtxId;
            existingEntity.IdDanhMucKhoanThu = newEntity.IdDanhMucKhoanThu;
            existingEntity.SoLuong = newEntity.SoLuong;
            existingEntity.DonGia = newEntity.DonGia;
            existingEntity.ThanhTien = newEntity.ThanhTien;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
}