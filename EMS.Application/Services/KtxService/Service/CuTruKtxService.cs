using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService.Service
{
    public class CuTruKtxService : BaseService<KtxCutru>, ICuTruKtxService
    {
        private readonly ICuTruKtxRepository _repository;

        public CuTruKtxService(IUnitOfWork unitOfWork, ICuTruKtxRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        protected override Task UpdateEntityProperties(KtxCutru existingEntity, KtxCutru newEntity)
        {
            existingEntity.SinhVienId = newEntity.SinhVienId;
            existingEntity.GiuongKtxId = newEntity.GiuongKtxId;
            existingEntity.DonKtxId = newEntity.DonKtxId;
            existingEntity.NgayBatDau = newEntity.NgayBatDau;
            existingEntity.NgayHetHan = newEntity.NgayHetHan;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
}