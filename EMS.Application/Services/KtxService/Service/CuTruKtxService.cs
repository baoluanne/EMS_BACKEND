using System.Linq.Expressions;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Enums;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.KtxService.Service
{
    public class CuTruKtxService : BaseService<KtxCutru>, ICuTruKtxService
    {
        private readonly ICuTruKtxRepository _repository;
        private readonly IKtxCuTruLichSuRepository _lichSuRepository;

        public CuTruKtxService(
            IUnitOfWork unitOfWork,
            ICuTruKtxRepository repository,
            IKtxCuTruLichSuRepository lichSuRepository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
            _lichSuRepository = lichSuRepository;
        }



        public async Task<List<KtxCuTruLichSu>> GetResidencyHistoryAsync(Guid sinhVienId)
        {
            return await _lichSuRepository.GetListAsync(
                filter: x => x.SinhVienId == sinhVienId,
                include: i => i
                    .Include(x => x.SinhVien)
                    .Include(x => x.DonKtx)
                    .Include(x => x.PhongMoi)
                    .Include(x => x.GiuongMoi)
                    .Include(x => x.PhongCu)
                    .Include(x => x.GiuongCu)
                    .Include(x => x.HocKy));
        }

        public async Task<List<KtxCuTruLichSu>> GetResidencyHistoryByDonAsync(Guid donId)
        {
            return await _lichSuRepository.GetListAsync(
                filter: x => x.DonKtxId == donId,
                include: i => i
                    .Include(x => x.SinhVien)
                    .Include(x => x.DonKtx)
                    .Include(x => x.PhongMoi)
                    .Include(x => x.GiuongMoi)
                    .Include(x => x.PhongCu)
                    .Include(x => x.GiuongCu)
                    .Include(x => x.HocKy));
        }

        public async Task<List<KtxCuTruLichSu>> GetResidencyHistoryByRoomAsync(Guid phongId)
        {
            return await _lichSuRepository.GetListAsync(
                filter: x => x.PhongMoiId == phongId,
                include: i => i
                    .Include(x => x.SinhVien)
                    .Include(x => x.PhongMoi)
                    .Include(x => x.GiuongMoi)
                    .Include(x => x.DonKtx));
        }

        protected override Task UpdateEntityProperties(KtxCutru existingEntity, KtxCutru newEntity)
        {
            existingEntity.SinhVienId = newEntity.SinhVienId;
            existingEntity.PhongKtxId = newEntity.PhongKtxId;
            existingEntity.GiuongKtxId = newEntity.GiuongKtxId;
            existingEntity.DonKtxId = newEntity.DonKtxId;
            existingEntity.IdHocKy = newEntity.IdHocKy;
            existingEntity.NgayBatDau = newEntity.NgayBatDau;
            existingEntity.NgayRoiKtx = newEntity.NgayRoiKtx;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
}