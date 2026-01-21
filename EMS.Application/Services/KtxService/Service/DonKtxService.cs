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
        private readonly ICuTruKtxRepository _cutruRepo;
        private readonly IGiuongKtxRepository _giuongKtxRepo;
        private readonly IKtxCuTruLichSuRepository _lichSuRepo;

        #region public method

        public DonKtxService(
            IUnitOfWork unitOfWork,
            IDonKtxRepository repository,
            IDonDangKyMoiRepository dangKyMoiRepo,
            IDonChuyenPhongRepository chuyenPhongRepo,
            IDonGiaHanRepository giaHanRepo,
            IDonRoiKtxRepository roiKtxRepo,
            IGiuongKtxRepository giuongrepo,
            ICuTruKtxRepository cutruRepo,
            IKtxCuTruLichSuRepository lichSuRepo)
            : base(unitOfWork, repository)
        {
            _repository = repository;
            _dangKyMoiRepo = dangKyMoiRepo;
            _chuyenPhongRepo = chuyenPhongRepo;
            _giaHanRepo = giaHanRepo;
            _roiKtxRepo = roiKtxRepo;
            _cutruRepo = cutruRepo;
            _giuongKtxRepo = giuongrepo;
            _lichSuRepo = lichSuRepo;
        }

        public override async Task<Result<KtxDon>> CreateAsync(KtxDon entity)
        {
            try
            {
                if (string.IsNullOrEmpty(entity.MaDon))
                {
                    entity.MaDon = GenerateMaDon(entity.LoaiDon);
                }
                entity.NgayGuiDon = DateTime.UtcNow;
                entity.TrangThai = KtxDonTrangThai.ChoDuyet;

                Repository.Add(entity);

                if (entity.LoaiDon == KtxLoaiDon.DangKyMoi && entity.PhongYeuCauId.HasValue)
                {
                    entity.DangKyMoi = new KtxDonDangKyMoi
                    {
                        DonKtxId = entity.Id,
                        PhongYeuCauId = entity.PhongYeuCauId.Value
                    };
                    _dangKyMoiRepo.Add(entity.DangKyMoi);
                }
                else if (entity.LoaiDon == KtxLoaiDon.ChuyenPhong && entity.PhongYeuCauId.HasValue)
                {
                    var currentStay = await _cutruRepo.GetFirstAsync(
                        predicate: x => x.SinhVienId == entity.IdSinhVien && x.TrangThai == KtxCutruTrangThai.DangO);

                    if (currentStay == null)
                    {
                        return new Result<KtxDon>(new Exception("Sinh viên hiện không nội trú tại ký túc xá"));
                    }

                    entity.ChuyenPhong = new KtxDonChuyenPhong
                    {
                        DonKtxId = entity.Id,
                        PhongYeuCauId = entity.PhongYeuCauId.Value,
                        PhongHienTaiId = currentStay.PhongKtxId,
                        GiuongHienTaiId = currentStay.GiuongKtxId
                    };
                    _chuyenPhongRepo.Add(entity.ChuyenPhong);
                }
                else if (entity.LoaiDon == KtxLoaiDon.GiaHan)
                {
                    entity.GiaHan!.DonKtxId = entity.Id;
                    _giaHanRepo.Add(entity.GiaHan);

                }
                else if (entity.LoaiDon == KtxLoaiDon.RoiKtx)
                {
                    var currentStay = await _cutruRepo.GetFirstAsync(
                        predicate: x => x.SinhVienId == entity.IdSinhVien && x.TrangThai == KtxCutruTrangThai.DangO);

                    if (currentStay == null)
                    {
                        return new Result<KtxDon>(new Exception("Sinh viên hiện không nội trú tại ký túc xá"));
                    }

                    entity.RoiKtx = new KtxDonRoiKtx
                    {
                        DonKtxId = entity.Id,
                        NgayRoiThucTe = DateTime.UtcNow,
                        PhongHienTaiId = currentStay.PhongKtxId,
                        GiuongHienTaiId = currentStay.GiuongKtxId
                    };
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

        public async Task<Result<bool>> ApproveRequestAsync(Guid id, Guid? phongDuyetId, Guid? giuongDuyetId)
        {
            try
            {
                var don = await _repository.GetFirstAsync(
                    predicate: x => x.Id == id,
                    include: i => i.Include(x => x.HocKy));

                if (don == null)
                    return new Result<bool>(new Exception("Không tìm thấy đơn"));

                don.TrangThai = KtxDonTrangThai.DaDuyet;
                don.NgayDuyet = DateTime.UtcNow;
                don.PhongDuocDuyetId = phongDuyetId;
                don.GiuongDuocDuyetId = giuongDuyetId;

                DateTime ngayRoiKtxDuKien = don.HocKy?.DenNgay ?? don.NgayHetHan;
                ngayRoiKtxDuKien = EnsureUtc(ngayRoiKtxDuKien);

                don.NgayBatDau = EnsureUtc(don.NgayBatDau);
                don.NgayHetHan = EnsureUtc(don.NgayHetHan);

                switch (don.LoaiDon)
                {
                    case KtxLoaiDon.DangKyMoi:
                        await ProcessNewRegistration(don, phongDuyetId, giuongDuyetId, ngayRoiKtxDuKien);
                        break;

                    case KtxLoaiDon.ChuyenPhong:
                        await ProcessRoomTransfer(don, phongDuyetId, giuongDuyetId, ngayRoiKtxDuKien);
                        break;

                    case KtxLoaiDon.GiaHan:
                        await ProcessExtension(don, ngayRoiKtxDuKien);
                        break;

                    case KtxLoaiDon.RoiKtx:
                        await ProcessCheckOut(don);
                        break;
                }

                _repository.Update(don);
                await UnitOfWork.CommitAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex.InnerException ?? ex);
            }
        }

        public async Task<Result<bool>> RejectRequestAsync(Guid id, string ghiChu)
        {
            try
            {
                var don = await _repository.GetByIdAsync(id);
                if (don == null)
                    return new Result<bool>(new Exception("Không tìm thấy đơn"));

                don.TrangThai = KtxDonTrangThai.TuChoi;
                don.NgayDuyet = DateTime.UtcNow;
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

        #endregion


        #region private methods 

        private async Task ProcessNewRegistration(KtxDon don, Guid? phongId, Guid? giuongId, DateTime ngayRoiKtx)
        {
            ngayRoiKtx = EnsureUtc(ngayRoiKtx);

            var giuong = await _giuongKtxRepo.GetByIdAsync(giuongId!);
            if (giuong != null)
            {
                giuong.TrangThai = KtxGiuongTrangThai.DaCoNguoi;
                giuong.SinhVienId = don.IdSinhVien;
                _giuongKtxRepo.Update(giuong);
            }

            var cuTru = new KtxCutru
            {
                Id = Guid.NewGuid(),
                SinhVienId = don.IdSinhVien,
                DonKtxId = don.Id,
                IdHocKy = don.IdHocKy,
                PhongKtxId = phongId!.Value,
                GiuongKtxId = giuongId!.Value,
                NgayBatDau = EnsureUtc(don.NgayBatDau),
                NgayRoiKtx = ngayRoiKtx,
                TrangThai = KtxCutruTrangThai.DangO,
                GhiChu = $"Duyệt từ đơn {don.MaDon}"
            };
            _cutruRepo.Add(cuTru);

            var lichSu = new KtxCuTruLichSu
            {
                CuTruId = cuTru.Id,
                SinhVienId = don.IdSinhVien,
                DonKtxId = don.Id,
                LoaiDon = don.LoaiDon,
                PhongMoiId = phongId!.Value,
                GiuongMoiId = giuongId!.Value,
                IdHocKy = don.IdHocKy,
                NgayBatDau = EnsureUtc(don.NgayBatDau),
                NgayRoiDuKien = ngayRoiKtx,
                TrangThai = KtxCutruTrangThai.DangO,
                NgayGhiLichSu = DateTime.UtcNow,
                GhiChu = $"Đăng ký mới từ đơn {don.MaDon}"
            };
            _lichSuRepo.Add(lichSu);
        }

        private async Task ProcessRoomTransfer(KtxDon don, Guid? phongId, Guid? giuongId, DateTime ngayRoiKtx)
        {
            ngayRoiKtx = EnsureUtc(ngayRoiKtx);

            var oldStay = await _cutruRepo.GetFirstAsync(
                predicate: x => x.SinhVienId == don.IdSinhVien && x.TrangThai == KtxCutruTrangThai.DangO);

            if (oldStay != null)
            {
                var lichSu = new KtxCuTruLichSu
                {
                    CuTruId = oldStay.Id,
                    SinhVienId = don.IdSinhVien,
                    DonKtxId = don.Id,
                    LoaiDon = don.LoaiDon,
                    PhongCuId = oldStay.PhongKtxId,
                    GiuongCuId = oldStay.GiuongKtxId,
                    PhongMoiId = phongId!.Value,
                    GiuongMoiId = giuongId!.Value,
                    IdHocKy = oldStay.IdHocKy,
                    NgayBatDau = EnsureUtc(oldStay.NgayBatDau),
                    NgayRoiDuKien = ngayRoiKtx,
                    TrangThai = KtxCutruTrangThai.DangO,
                    NgayGhiLichSu = DateTime.UtcNow,
                    GhiChu = $"Chuyển phòng từ đơn {don.MaDon}"
                };
                _lichSuRepo.Add(lichSu);

                var oldGiuong = await _giuongKtxRepo.GetByIdAsync(oldStay.GiuongKtxId);
                if (oldGiuong != null)
                {
                    oldGiuong.TrangThai = KtxGiuongTrangThai.Trong;
                    oldGiuong.SinhVienId = null;
                    _giuongKtxRepo.Update(oldGiuong);
                }

                oldStay.PhongKtxId = phongId!.Value;
                oldStay.GiuongKtxId = giuongId!.Value;
                oldStay.DonKtxId = don.Id;
                oldStay.NgayRoiKtx = ngayRoiKtx;
                _cutruRepo.Update(oldStay);

                var giuong = await _giuongKtxRepo.GetByIdAsync(giuongId!);
                if (giuong != null)
                {
                    giuong.TrangThai = KtxGiuongTrangThai.DaCoNguoi;
                    giuong.SinhVienId = don.IdSinhVien;
                    _giuongKtxRepo.Update(giuong);
                }
            }
        }

        private async Task ProcessExtension(KtxDon don, DateTime ngayRoiKtxMoi)
        {
            ngayRoiKtxMoi = EnsureUtc(ngayRoiKtxMoi);

            var stay = await _cutruRepo.GetFirstAsync(
                predicate: x => x.SinhVienId == don.IdSinhVien && x.TrangThai == KtxCutruTrangThai.DangO);

            if (stay != null)
            {
                var lichSu = new KtxCuTruLichSu
                {
                    CuTruId = stay.Id,
                    SinhVienId = don.IdSinhVien,
                    DonKtxId = don.Id,
                    LoaiDon = don.LoaiDon,
                    PhongMoiId = stay.PhongKtxId,
                    GiuongMoiId = stay.GiuongKtxId,
                    IdHocKy = don.IdHocKy,
                    NgayBatDau = EnsureUtc(stay.NgayBatDau),
                    NgayRoiDuKien = ngayRoiKtxMoi,
                    TrangThai = KtxCutruTrangThai.DangO,
                    NgayGhiLichSu = DateTime.UtcNow,
                    GhiChu = $"Gia hạn từ đơn {don.MaDon}"
                };
                _lichSuRepo.Add(lichSu);

                stay.IdHocKy = don.IdHocKy;
                stay.NgayRoiKtx = ngayRoiKtxMoi;
                stay.DonKtxId = don.Id;
                _cutruRepo.Update(stay);
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
            return $"{prefix}-{DateTime.UtcNow:yyyyMMddHHmmss}";
        }

        private DateTime EnsureUtc(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
                return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            if (dateTime.Kind == DateTimeKind.Local)
                return dateTime.ToUniversalTime();
            return dateTime;
        }

        private async Task ProcessCheckOut(KtxDon don)
        {
            var stay = await _cutruRepo.GetFirstAsync(
                predicate: x => x.SinhVienId == don.IdSinhVien && x.TrangThai == KtxCutruTrangThai.DangO);

            if (stay != null)
            {
                var lichSu = new KtxCuTruLichSu
                {
                    CuTruId = stay.Id,
                    SinhVienId = don.IdSinhVien,
                    DonKtxId = don.Id,
                    LoaiDon = don.LoaiDon,
                    PhongMoiId = stay.PhongKtxId,
                    GiuongMoiId = stay.GiuongKtxId,
                    IdHocKy = stay.IdHocKy,
                    NgayBatDau = EnsureUtc(stay.NgayBatDau),
                    NgayRoiDuKien = EnsureUtc(stay.NgayRoiKtx),
                    NgayRoiThucTe = DateTime.UtcNow,
                    TrangThai = KtxCutruTrangThai.DaRa,
                    NgayGhiLichSu = DateTime.UtcNow,
                    GhiChu = $"Rời KTX từ đơn {don.MaDon}"
                };
                _lichSuRepo.Add(lichSu);

                stay.TrangThai = KtxCutruTrangThai.DaRa;
                stay.NgayRoiKtx = DateTime.UtcNow;
                _cutruRepo.Update(stay);

                var giuong = await _giuongKtxRepo.GetByIdAsync(stay.GiuongKtxId);
                if (giuong != null)
                {
                    giuong.TrangThai = KtxGiuongTrangThai.Trong;
                    giuong.SinhVienId = null;
                    _giuongKtxRepo.Update(giuong);
                }
            }
        }

        #endregion
        

        #region protected

        protected override Task UpdateEntityProperties(KtxDon existingEntity, KtxDon newEntity)
        {
            existingEntity.LoaiDon = newEntity.LoaiDon;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.NgayDuyet = newEntity.NgayDuyet;
            existingEntity.NgayBatDau = EnsureUtc(newEntity.NgayBatDau);
            existingEntity.NgayHetHan = EnsureUtc(newEntity.NgayHetHan);
            existingEntity.IdGoiDichVu = newEntity.IdGoiDichVu;
            existingEntity.PhongDuocDuyetId = newEntity.PhongDuocDuyetId;
            existingEntity.GiuongDuocDuyetId = newEntity.GiuongDuocDuyetId;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }

        #endregion 

    }
}