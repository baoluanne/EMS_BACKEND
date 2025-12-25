using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories.KtxManagement
{
    public class DonKtxRepository(DbFactory dbFactory)
        : AuditRepository<DonKtx>(dbFactory), IDonKtxRepository
    {
        public async Task<(List<DonKtxResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(
            PaginationRequest request,
            string? trangThai = null,
            string? loaiDon = null)
        {
            var query = DbSet
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .Include(d => d.SinhVien)
                .ThenInclude(s => s.CuTruKtxs)
                .Include(d => d.PhongHienTainav)
                .Include(d => d.PhongMongMuonnav)
                .Include(d => d.PhongKtx)
                .AsQueryable();

            if (!string.IsNullOrEmpty(trangThai))
                query = query.Where(d => d.TrangThai == trangThai);
            if (!string.IsNullOrEmpty(loaiDon))
                query = query.Where(d => d.LoaiDon == loaiDon);

            var selectQuery = query.Select(d => new DonKtxResponseDto
            {
                Id = d.Id,
                MaDon = d.MaDon ?? "",
                SinhVienId = d.IdSinhVien,
                MaSinhVien = d.SinhVien != null ? d.SinhVien.MaSinhVien ?? "" : "",
                HoTenSinhVien = d.SinhVien != null
                    ? $"{d.SinhVien.HoDem} {d.SinhVien.Ten}".Trim()
                    : "Sinh viên không tồn tại",
                LoaiDon = d.LoaiDon ?? "",
                TrangThai = d.TrangThai ?? "",
                NgayGuiDon = d.NgayGuiDon,
                LyDo = d.LyDoChuyen ?? d.Ghichu,
                GhiChuDuyet = d.Ghichu,
                MaPhongHienTai = d.PhongDuocDuyet != null && d.PhongKtx != null
    ? d.PhongKtx.MaPhong
    : d.PhongHienTainav != null
        ? d.PhongHienTainav.MaPhong
        : null,
                MaPhongMuonChuyen = d.PhongMongMuonnav != null ? d.PhongMongMuonnav.MaPhong : null,
                MaPhongDuocDuyet = d.PhongKtx != null ? d.PhongKtx.MaPhong : null,

                NgayBatDauMongMuon = d.NgayBatDau,
                NgayHetHanMongMuon = d.NgayHetHan,

                NgayBatDauHienTai = d.SinhVien != null
                    ? d.SinhVien.CuTruKtxs
                        .Where(c => c.TrangThai == TrangThaiCuTruConstants.DANG_O)
                        .OrderByDescending(c => c.NgayBatDau)
                        .Select(c => (DateTime?)c.NgayBatDau)
                        .FirstOrDefault()
                    : null,

                NgayHetHanHienTai = d.SinhVien != null
                    ? d.SinhVien.CuTruKtxs
                        .Where(c => c.TrangThai == TrangThaiCuTruConstants.DANG_O)
                        .OrderByDescending(c => c.NgayBatDau)
                        .Select(c => (DateTime?)c.NgayHetHan)
                        .FirstOrDefault()
                    : null,
            });

            var total = await selectQuery.CountAsync();
            var data = await selectQuery
                .OrderByDescending(d => d.NgayGuiDon)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return (data, total);
        }
    }
}