using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public class CuTruKtxService : BaseService<KtxCutru>, ICuTruKtxService
    {
        private readonly ICuTruKtxRepository _cuTruRepository;
        private readonly IGiuongKtxRepository _giuongRepository;

        public CuTruKtxService(
            IUnitOfWork unitOfWork,
            ICuTruKtxRepository cuTruRepository,
            IGiuongKtxRepository giuongRepository)
            : base(unitOfWork, cuTruRepository)
        {
            _cuTruRepository = cuTruRepository;
            _giuongRepository = giuongRepository;
        }

        public async Task<Result<KtxCutru>> TaoHopDongMoiAsync(
            Guid sinhVienId, Guid giuongId, DateTime ngayBatDau, DateTime ngayHetHan,
            Guid? donKtxId = null, string? ghiChu = null)
        {
            try
            {
                var giuong = await _giuongRepository.GetByIdAsync(giuongId);
                if (giuong == null || giuong.TrangThai != TrangThaiGiuongConstants.TRONG)
                    return new Result<KtxCutru>(new BadRequestException("Giường không khả dụng"));

                var hopDongHienTai = await _cuTruRepository.GetHopDongHienTaiAsync(sinhVienId);
                if (hopDongHienTai != null)
                    return new Result<KtxCutru>(new BadRequestException("Sinh viên đang có hợp đồng cư trú"));

                var hopDong = new KtxCutru
                {
                    Id = Guid.NewGuid(),
                    SinhVienId = sinhVienId,
                    GiuongKtxId = giuongId,
                    NgayBatDau = ngayBatDau,
                    NgayHetHan = ngayHetHan,
                    TrangThai = TrangThaiCuTruConstants.DANG_O,
                    GhiChu = ghiChu,
                    DonKtxId = donKtxId
                };

                Repository.Add(hopDong);
                await UnitOfWork.CommitAsync();
                return new Result<KtxCutru>(hopDong);
            }
            catch (Exception ex)
            {
                return new Result<KtxCutru>(ex);
            }
        }

        public async Task<Result<bool>> GiaHanHopDongAsync(Guid sinhVienId, DateTime ngayHetHanMoi, string? ghiChu = null)
        {
            try
            {
                var hopDong = await _cuTruRepository.GetHopDongHienTaiAsync(sinhVienId);
                if (hopDong == null)
                    return new Result<bool>(new NotFoundException("Không tìm thấy hợp đồng hiện tại"));

                if (ngayHetHanMoi <= hopDong.NgayHetHan)
                    return new Result<bool>(new BadRequestException("Ngày hết hạn mới phải sau ngày hiện tại"));

                hopDong.NgayHetHan = ngayHetHanMoi;
                hopDong.GhiChu = string.IsNullOrEmpty(ghiChu)
                    ? hopDong.GhiChu
                    : (hopDong.GhiChu + " | Gia hạn: " + ghiChu);

                Repository.Update(hopDong);
                await UnitOfWork.CommitAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

        public async Task<Result<bool>> KetThucHopDongAsync(Guid sinhVienId, string? ghiChu = null)
        {
            try
            {
                var hopDong = await _cuTruRepository.GetHopDongHienTaiAsync(sinhVienId);
                if (hopDong == null)
                    return new Result<bool>(new NotFoundException("Không tìm thấy hợp đồng hiện tại"));

                hopDong.TrangThai = TrangThaiCuTruConstants.DA_KET_THUC;
                hopDong.NgayHetHan = DateTime.UtcNow;
                hopDong.GhiChu = string.IsNullOrEmpty(ghiChu)
                    ? hopDong.GhiChu
                    : (hopDong.GhiChu + " | Kết thúc: " + ghiChu);

                Repository.Update(hopDong);
                await UnitOfWork.CommitAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

        public async Task<Result<KtxCutru?>> GetHopDongHienTaiAsync(Guid sinhVienId)
        {
            try
            {
                var hopDong = await _cuTruRepository.GetHopDongHienTaiAsync(sinhVienId);
                return new Result<KtxCutru?>(hopDong);
            }
            catch (Exception ex)
            {
                return new Result<KtxCutru?>(ex);
            }
        }

        protected override Task UpdateEntityProperties(KtxCutru existingEntity, KtxCutru newEntity)
        {
            existingEntity.NgayBatDau = newEntity.NgayBatDau;
            existingEntity.NgayHetHan = newEntity.NgayHetHan;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.GiuongKtxId = newEntity.GiuongKtxId;
            existingEntity.DonKtxId = newEntity.DonKtxId;
            return Task.CompletedTask;
        }
        public async Task<Result<ThongTinSinhVienKtxPagingResponse>> GetPaginatedSinhVienDangOAsync(
             PaginationRequest request,
             string? maSinhVien = null,
             string? hoTen = null,
             string? maPhong = null)
        {
            try
            {
                var (data, total) = await _cuTruRepository.GetPaginatedSinhVienDangOAsync(
                    request, maSinhVien, hoTen, maPhong);

                return new Result<ThongTinSinhVienKtxPagingResponse>(
                    new ThongTinSinhVienKtxPagingResponse
                    {
                        Data = data,
                        Total = total
                    });
            }
            catch (Exception ex)
            {
                return new Result<ThongTinSinhVienKtxPagingResponse>(ex);
            }
        }
    }
}