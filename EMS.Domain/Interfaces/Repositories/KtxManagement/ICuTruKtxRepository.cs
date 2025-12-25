using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;

namespace EMS.Domain.Interfaces.Repositories.KtxManagement
{
    public interface ICuTruKtxRepository : IAuditRepository<CuTruKtx>
    {
        Task<CuTruKtx?> GetHopDongHienTaiAsync(Guid sinhVienId);
        Task<CuTruKtx?> GetHopDongHienTaiByGiuongAsync(Guid giuongId);
        Task<(List<ThongTinSinhVienKtxResponseDto> Data, int Total)> GetPaginatedSinhVienDangOAsync(
             PaginationRequest request,
             string? maSinhVien = null,
             string? hoTen = null,
             string? maPhong = null);
    }
}