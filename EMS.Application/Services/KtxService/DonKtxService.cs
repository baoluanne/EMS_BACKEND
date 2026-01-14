using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public class DonKtxService : BaseService<KtxDon>, IDonKtxService
    {
        private readonly IDonKtxRepository _donRepository;
        private readonly IGiuongKtxRepository _giuongRepository;
        private readonly IPhongKtxRepository _phongRepository;
        private readonly ICuTruKtxRepository _cuTruRepository;

        public DonKtxService(
            IUnitOfWork unitOfWork,
            IDonKtxRepository donRepository,
            IGiuongKtxRepository giuongRepository,
            IPhongKtxRepository phongRepository,
            ICuTruKtxRepository cuTruRepository)
            : base(unitOfWork, donRepository)
        {
            _donRepository = donRepository;
            _giuongRepository = giuongRepository;
            _phongRepository = phongRepository;
            _cuTruRepository = cuTruRepository;
        }

        public async Task<Result<Guid>> AddDonAsync(DonKtxCreateDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.LoaiDon))
                    return new Result<Guid>(new BadRequestException("Loại đơn là bắt buộc"));

                var entity = new KtxDon
                {
                    MaDon = "KTX" + dto.LoaiDon + DateTime.Now.ToString("yyyyMMddHHmmss"),
                    Id = Guid.NewGuid(),
                    IdSinhVien = dto.IdSinhVien,
                    LoaiDon = dto.LoaiDon.Trim(),
                    TrangThai = TrangThaiDonConstants.CHO_PHE_DUYET,
                    NgayGuiDon = DateTime.UtcNow,
                    NgayBatDau = dto.NgayBatDau == default ? DateTime.UtcNow : dto.NgayBatDau,
                    NgayHetHan = dto.NgayHetHan ?? DateTime.UtcNow.AddYears(1),
                    Ghichu = dto.Ghichu,
                    PhongHienTai = dto.PhongHienTai,
                    phongMuonChuyen = dto.phongMuonChuyen,
                    LyDoChuyen = dto.LyDoChuyen
                };

                Repository.Add(entity);
                await UnitOfWork.CommitAsync();
                return new Result<Guid>(entity.Id);
            }
            catch (Exception ex)
            {
                return new Result<Guid>(ex);
            }
        }

        public async Task<Result<DonKtxPagingResponse>> GetPaginatedWithDetailsAsync(
            PaginationRequest request, string? trangThai = null, string? loaiDon = null)
        {
            try
            {
                var (data, total) = await _donRepository.GetPaginatedWithDetailsAsync(request, trangThai, loaiDon);
                return new Result<DonKtxPagingResponse>(new DonKtxPagingResponse { Data = data, Total = total });
            }
            catch (Exception ex)
            {
                return new Result<DonKtxPagingResponse>(ex);
            }
        }

        public async Task<Result<bool>> DuyetDonVaoOAsync(Guid donId, Guid phongId, Guid giuongId, string? ghiChuDuyet = null)
        {
            try
            {
                var don = await Repository.GetFirstAsync(d => d.Id == donId && !d.IsDeleted);
                if (don == null)
                    return new Result<bool>(new NotFoundException($"Đơn với ID {donId} không tồn tại"));

                if (don.TrangThai != TrangThaiDonConstants.CHO_PHE_DUYET)
                    return new Result<bool>(new BadRequestException($"Đơn không ở trạng thái chờ duyệt. Trạng thái hiện tại: {don.TrangThai}"));

                if (don.LoaiDon != LoaiDonConstants.VAO_O)
                    return new Result<bool>(new BadRequestException($"Loại đơn không phù hợp. Yêu cầu loại: {LoaiDonConstants.VAO_O}"));

                var phong = await _phongRepository.GetFirstAsync(p => p.Id == phongId && !p.IsDeleted);
                if (phong == null)
                    return new Result<bool>(new NotFoundException($"Phòng với ID {phongId} không tồn tại"));

                var giuong = await _giuongRepository.GetFirstAsync(g => g.Id == giuongId && g.PhongKtxId == phongId && !g.IsDeleted);
                if (giuong == null)
                    return new Result<bool>(new NotFoundException($"Giường với ID {giuongId} không tồn tại trong phòng {phongId}"));

                if (giuong.TrangThai != TrangThaiGiuongConstants.TRONG)
                    return new Result<bool>(new BadRequestException($"Giường không còn trống. Trạng thái: {giuong.TrangThai}"));

                var hopDongHienTai = await _cuTruRepository.GetHopDongHienTaiAsync(don.IdSinhVien);
                if (hopDongHienTai != null)
                    return new Result<bool>(new BadRequestException("Sinh viên đang có hợp đồng cư trú hiện tại"));

                don.PhongDuocDuyet = phongId;
                don.GiuongDuocDuyet = giuongId;
                don.TrangThai = TrangThaiDonConstants.DA_DUYET;
                don.Ghichu = !string.IsNullOrEmpty(ghiChuDuyet)
                    ? (don.Ghichu ?? "") + $" [Duyệt vào ở: {ghiChuDuyet}]"
                    : (don.Ghichu ?? "") + " [Duyệt vào ở]";

                giuong.TrangThai = TrangThaiGiuongConstants.CO_SV;
                giuong.SinhVienId = don.IdSinhVien;

                phong.SoLuongDaO += 1;

                var cuTru = new KtxCutru
                {
                    Id = Guid.NewGuid(),
                    SinhVienId = don.IdSinhVien,
                    GiuongKtxId = giuongId,
                    NgayBatDau = don.NgayBatDau,
                    NgayHetHan = don.NgayHetHan,
                    TrangThai = TrangThaiCuTruConstants.DANG_O,
                    GhiChu = $"Tạo từ đơn vào ở {don.MaDon}. {ghiChuDuyet}",
                    DonKtxId = don.Id
                };

                Repository.Update(don);
                _giuongRepository.Update(giuong);
                _phongRepository.Update(phong);
                _cuTruRepository.Add(cuTru);

                await UnitOfWork.CommitAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

        public async Task<Result<bool>> DuyetDonChuyenPhongAsync(
            Guid donId, Guid phongMoiId, Guid giuongMoiId,
            DateTime ngayBatDau, DateTime ngayHetHan,
            string? ghiChuDuyet = null)
        {
            try
            {
                var don = await Repository.GetFirstAsync(d => d.Id == donId && !d.IsDeleted);
                if (don == null)
                    return new Result<bool>(new NotFoundException("Đơn không tồn tại"));

                if (don.TrangThai != TrangThaiDonConstants.CHO_PHE_DUYET)
                    return new Result<bool>(new BadRequestException("Đơn không ở trạng thái chờ duyệt"));

                if (don.LoaiDon != LoaiDonConstants.CHUYEN_PHONG)
                    return new Result<bool>(new BadRequestException("Loại đơn không phải chuyển phòng"));

                var hopDongHienTai = await _cuTruRepository.GetHopDongHienTaiAsync(don.IdSinhVien);
                if (hopDongHienTai == null)
                    return new Result<bool>(new BadRequestException("Sinh viên không có hợp đồng cư trú hiện tại"));

                var giuongCu = await _giuongRepository.GetByIdAsync(hopDongHienTai.GiuongKtxId);
                if (giuongCu != null)
                {
                    giuongCu.TrangThai = TrangThaiGiuongConstants.TRONG;
                    giuongCu.SinhVienId = null;
                    _giuongRepository.Update(giuongCu);

                    var phongCu = await _phongRepository.GetByIdAsync(giuongCu.PhongKtxId);
                    if (phongCu != null && phongCu.SoLuongDaO > 0)
                    {
                        phongCu.SoLuongDaO -= 1;
                        _phongRepository.Update(phongCu);
                    }
                }

                var giuongMoi = await _giuongRepository.GetFirstAsync(
                    g => g.Id == giuongMoiId && g.PhongKtxId == phongMoiId && g.TrangThai == TrangThaiGiuongConstants.TRONG);
                if (giuongMoi == null)
                    return new Result<bool>(new BadRequestException("Giường mới không khả dụng"));

                var phongMoi = await _phongRepository.GetByIdAsync(phongMoiId);
                if (phongMoi == null)
                    return new Result<bool>(new NotFoundException("Phòng mới không tồn tại"));

                giuongMoi.TrangThai = TrangThaiGiuongConstants.CO_SV;
                giuongMoi.SinhVienId = don.IdSinhVien;
                phongMoi.SoLuongDaO += 1;

                hopDongHienTai.TrangThai = TrangThaiCuTruConstants.DA_KET_THUC;
                hopDongHienTai.NgayHetHan = DateTime.UtcNow;
                hopDongHienTai.GhiChu += $" [Kết thúc do chuyển phòng]";
                hopDongHienTai.GiuongKtx = null;

                var hopDongMoi = new KtxCutru
                {
                    Id = Guid.NewGuid(),
                    SinhVienId = don.IdSinhVien,
                    GiuongKtxId = giuongMoiId,
                    NgayBatDau = ngayBatDau,
                    NgayHetHan = ngayHetHan,
                    TrangThai = TrangThaiCuTruConstants.DANG_O,
                    GhiChu = $"Tạo từ đơn chuyển phòng {don.MaDon}. {ghiChuDuyet}",
                    DonKtxId = don.Id
                };

                don.PhongDuocDuyet = phongMoiId;
                don.GiuongDuocDuyet = giuongMoiId;
                don.TrangThai = TrangThaiDonConstants.DA_DUYET;
                don.Ghichu += $" [Duyệt chuyển phòng: {ghiChuDuyet}]";

                Repository.Update(don);
                _giuongRepository.Update(giuongMoi);
                _phongRepository.Update(phongMoi);
                _cuTruRepository.Update(hopDongHienTai);
                _cuTruRepository.Add(hopDongMoi);

                await UnitOfWork.CommitAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

        public async Task<Result<bool>> DuyetDonGiaHanAsync(Guid donId, DateTime ngayHetHanMoi, string? ghiChuDuyet = null)
        {
            try
            {
                var don = await Repository.GetFirstAsync(d => d.Id == donId && !d.IsDeleted);
                if (don == null)
                    return new Result<bool>(new NotFoundException("Đơn không tồn tại"));

                if (don.TrangThai != TrangThaiDonConstants.CHO_PHE_DUYET)
                    return new Result<bool>(new BadRequestException("Đơn không ở trạng thái chờ duyệt"));

                if (don.LoaiDon != LoaiDonConstants.GIA_HAN_KTX)
                    return new Result<bool>(new BadRequestException("Loại đơn không phải gia hạn"));

                var hopDongHienTai = await _cuTruRepository.GetHopDongHienTaiAsync(don.IdSinhVien);
                if (hopDongHienTai == null)
                    return new Result<bool>(new BadRequestException("Sinh viên không có hợp đồng cư trú hiện tại để gia hạn"));

                if (ngayHetHanMoi <= hopDongHienTai.NgayHetHan)
                    return new Result<bool>(new BadRequestException("Ngày hết hạn mới phải sau ngày hiện tại"));

                hopDongHienTai.NgayHetHan = ngayHetHanMoi;
                hopDongHienTai.GhiChu += $" [Gia hạn đến {ngayHetHanMoi:dd/MM/yyyy}: {ghiChuDuyet}]";

                don.TrangThai = TrangThaiDonConstants.DA_DUYET;
                don.Ghichu += $" [Duyệt gia hạn: {ghiChuDuyet}]";

                _cuTruRepository.Update(hopDongHienTai);
                Repository.Update(don);

                await UnitOfWork.CommitAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

        public async Task<Result<bool>> DuyetDonRoiKtxAsync(Guid donId, string? ghiChuDuyet = null)
        {
            try
            {
                var don = await Repository.GetFirstAsync(d => d.Id == donId && !d.IsDeleted);
                if (don == null)
                    return new Result<bool>(new NotFoundException($"Đơn với ID {donId} không tồn tại"));

                if (don.TrangThai != TrangThaiDonConstants.CHO_PHE_DUYET)
                    return new Result<bool>(new BadRequestException($"Đơn không ở trạng thái chờ duyệt."));

                if (don.LoaiDon != LoaiDonConstants.ROI_KTX)
                    return new Result<bool>(new BadRequestException($"Loại đơn không phù hợp."));

                var giuongHienTai = await _giuongRepository.GetFirstAsync(g => g.SinhVienId == don.IdSinhVien && !g.IsDeleted);
                if (giuongHienTai != null)
                {
                    giuongHienTai.TrangThai = TrangThaiGiuongConstants.TRONG;
                    giuongHienTai.SinhVienId = null;
                    _giuongRepository.Update(giuongHienTai);

                    var phongHienTai = await _phongRepository.GetFirstAsync(p => p.Id == giuongHienTai.PhongKtxId && !p.IsDeleted);
                    if (phongHienTai != null && phongHienTai.SoLuongDaO > 0)
                    {
                        phongHienTai.SoLuongDaO -= 1;
                        _phongRepository.Update(phongHienTai);
                    }
                }

                var hopDongHienTai = await _cuTruRepository.GetHopDongHienTaiAsync(don.IdSinhVien);
                if (hopDongHienTai != null)
                {
                    hopDongHienTai.TrangThai = TrangThaiCuTruConstants.DA_KET_THUC;
                    hopDongHienTai.NgayHetHan = DateTime.UtcNow;
                    hopDongHienTai.GiuongKtx = null;
                    hopDongHienTai.GhiChu = string.IsNullOrEmpty(ghiChuDuyet)
                        ? hopDongHienTai.GhiChu
                        : (hopDongHienTai.GhiChu ?? "") + $" [Rời KTX: {ghiChuDuyet}]";
                    _cuTruRepository.Update(hopDongHienTai);
                }

                don.TrangThai = TrangThaiDonConstants.DA_DUYET;
                don.Ghichu = string.IsNullOrEmpty(ghiChuDuyet)
                    ? (don.Ghichu ?? "") + " [Duyệt rời KTX]"
                    : (don.Ghichu ?? "") + $" [Duyệt rời KTX: {ghiChuDuyet}]";
                don.NgayHetHan = DateTime.UtcNow;

                Repository.Update(don);
                await UnitOfWork.CommitAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

        public async Task<Result<bool>> TuChoiDonAsync(Guid donId, string lyDoTuChoi)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(lyDoTuChoi))
                    return new Result<bool>(new BadRequestException("Lý do từ chối không được để trống"));

                var don = await Repository.GetFirstAsync(d => d.Id == donId && !d.IsDeleted);
                if (don == null)
                    return new Result<bool>(new NotFoundException($"Đơn với ID {donId} không tồn tại"));

                if (don.TrangThai != TrangThaiDonConstants.CHO_PHE_DUYET)
                    return new Result<bool>(new BadRequestException($"Đơn không ở trạng thái chờ duyệt. Trạng thái hiện tại: {don.TrangThai}"));

                don.TrangThai = TrangThaiDonConstants.TU_CHOI;
                don.Ghichu = (don.Ghichu ?? "") + $" [Từ chối: {lyDoTuChoi}]";

                Repository.Update(don);
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
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.Ghichu = newEntity.Ghichu;
            existingEntity.PhongDuocDuyet = newEntity.PhongDuocDuyet;
            existingEntity.GiuongDuocDuyet = newEntity.GiuongDuocDuyet;
            return Task.CompletedTask;
        }
    }
}