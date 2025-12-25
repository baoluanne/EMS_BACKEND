using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService
{
    public interface ICuTruKtxService : IBaseService<CuTruKtx>
    {
        Task<Result<CuTruKtx>> TaoHopDongMoiAsync(
            Guid sinhVienId, Guid giuongId, DateTime ngayBatDau, DateTime ngayHetHan,
            Guid? donKtxId = null, string? ghiChu = null);

        Task<Result<bool>> GiaHanHopDongAsync(Guid sinhVienId, DateTime ngayHetHanMoi, string? ghiChu = null);

        Task<Result<bool>> KetThucHopDongAsync(Guid sinhVienId, string? ghiChu = null);

        Task<Result<CuTruKtx?>> GetHopDongHienTaiAsync(Guid sinhVienId);
        Task<Result<ThongTinSinhVienKtxPagingResponse>> GetPaginatedSinhVienDangOAsync(
            PaginationRequest request, string? maSinhVien = null, string? hoTen = null, string? maPhong = null);
    }
}