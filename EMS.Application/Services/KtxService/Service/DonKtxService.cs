using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Enums;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.KtxService.Service
{
    public class DonKtxService : BaseService<KtxDon>, IDonKtxService
    {
        private readonly IDonKtxRepository _repository;
        private readonly IDonDangKyMoiRepository _dangKyMoiRepo;
        private readonly IDonChuyenPhongRepository _chuyenPhongRepo;
        private readonly IDonGiaHanRepository _giaHanRepo;
        private readonly IDonRoiKtxRepository _roiKtxRepo;

        public DonKtxService(
            IUnitOfWork unitOfWork,
            IDonKtxRepository repository,
            IDonDangKyMoiRepository dangKyMoiRepo,
            IDonChuyenPhongRepository chuyenPhongRepo,
            IDonGiaHanRepository giaHanRepo,
            IDonRoiKtxRepository roiKtxRepo)
            : base(unitOfWork, repository)
        {
            _repository = repository;
            _dangKyMoiRepo = dangKyMoiRepo;
            _chuyenPhongRepo = chuyenPhongRepo;
            _giaHanRepo = giaHanRepo;
            _roiKtxRepo = roiKtxRepo;
        }

        public override async Task<Result<KtxDon>> CreateAsync(KtxDon entity)
        {
            try
            {
                if (string.IsNullOrEmpty(entity.MaDon))
                {
                    entity.MaDon = GenerateMaDon(entity.LoaiDon);
                }
                entity.NgayGuiDon = DateTime.Now;
                entity.TrangThai = KtxDonTrangThai.ChoDuyet;

                Repository.Add(entity);

                if (entity.DangKyMoi != null)
                {
                    entity.DangKyMoi.DonKtxId = entity.Id;
                    _dangKyMoiRepo.Add(entity.DangKyMoi);
                }

                if (entity.ChuyenPhong != null)
                {
                    entity.ChuyenPhong.DonKtxId = entity.Id;
                    _chuyenPhongRepo.Add(entity.ChuyenPhong);
                }

                if (entity.GiaHan != null)
                {
                    entity.GiaHan.DonKtxId = entity.Id;
                    _giaHanRepo.Add(entity.GiaHan);
                }

                if (entity.RoiKtx != null)
                {
                    entity.RoiKtx.DonKtxId = entity.Id;
                    _roiKtxRepo.Add(entity.RoiKtx);
                }
                await UnitOfWork.CommitAsync();

                return new Result<KtxDon>(entity);
            }
            catch (Exception ex)
            {
                return new Result<KtxDon>(ex.InnerException ?? ex);
            }
        }

        private string GenerateMaDon(KtxLoaiDon loaiDon)
        {
            var prefix = loaiDon switch
            {
                KtxLoaiDon.DangKyMoi => "DKM",
                KtxLoaiDon.ChuyenPhong => "DCP",
                KtxLoaiDon.GiaHan => "DGH",
                KtxLoaiDon.RoiKtx => "DRK",
                _ => "DON"
            };
            return $"{prefix}-{DateTime.Now:yyyyMMddHHmmss}";
        }

        public async Task<Result<bool>> ApproveRequestAsync(Guid id, Guid? phongDuyetId, Guid? giuongDuyetId)
        {
            try
            {
                var don = await _repository.GetByIdAsync(id);
                if (don == null) return new Result<bool>(new Exception("Not Found"));

                don.TrangThai = KtxDonTrangThai.DaDuyet;
                don.NgayDuyet = DateTime.Now;
                don.PhongDuocDuyetId = phongDuyetId;
                don.GiuongDuocDuyetId = giuongDuyetId;

                _repository.Update(don);
                await UnitOfWork.CommitAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

        public async Task<Result<bool>> RejectRequestAsync(Guid id, string ghiChu)
        {
            try
            {
                var don = await _repository.GetByIdAsync(id);
                if (don == null) return new Result<bool>(new Exception("Not Found"));

                don.TrangThai = KtxDonTrangThai.TuChoi;
                don.NgayDuyet = DateTime.Now;
                don.GhiChu = ghiChu;

                _repository.Update(don);
                await UnitOfWork.CommitAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

        protected override Task UpdateEntityProperties(KtxDon existingEntity, KtxDon newEntity)
        {
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