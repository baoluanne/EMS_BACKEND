using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService.Service
{
    public class DonKtxService : BaseService<KtxDon>, IDonKtxService
    {
        private readonly IDonKtxRepository _repository;

        public DonKtxService(IUnitOfWork unitOfWork, IDonKtxRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        protected override Task UpdateEntityProperties(KtxDon existingEntity, KtxDon newEntity)
        {
            existingEntity.MaDon = newEntity.MaDon;
            existingEntity.LoaiDon = newEntity.LoaiDon;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.NgayDuyet = newEntity.NgayDuyet;
            existingEntity.NgayBatDau = newEntity.NgayBatDau;
            existingEntity.NgayHetHan = newEntity.NgayHetHan;
            existingEntity.IdGoiDichVu = newEntity.IdGoiDichVu;
            existingEntity.PhongDuocDuyetId = newEntity.PhongDuocDuyetId;
            existingEntity.GiuongDuocDuyetId = newEntity.GiuongDuocDuyetId;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }

}