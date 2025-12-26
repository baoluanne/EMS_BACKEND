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
    public class CuTruKtxRepository(DbFactory dbFactory)
        : AuditRepository<CuTruKtx>(dbFactory), ICuTruKtxRepository
    {
        public async Task<CuTruKtx?> GetHopDongHienTaiAsync(Guid sinhVienId)
        {
            return await DbSet
                .AsNoTracking().Include(i => i.GiuongKtx).ThenInclude(i => i.PhongKtx).Include(i => i.SinhVien)
                .Where(c => c.SinhVienId == sinhVienId &&
                            c.TrangThai == "DangO" &&
                            c.NgayHetHan >= DateTime.UtcNow.Date)
                .OrderByDescending(c => c.NgayBatDau)
                .FirstOrDefaultAsync();
        }

        public async Task<CuTruKtx?> GetHopDongHienTaiByGiuongAsync(Guid giuongId)
        {
            return await DbSet
                .AsNoTracking()
                .Where(c => c.GiuongKtxId == giuongId &&
                            c.TrangThai == "DangO" &&
                            c.NgayHetHan >= DateTime.UtcNow.Date)
                .FirstOrDefaultAsync();
        }
        public async Task<(List<ThongTinSinhVienKtxResponseDto> Data, int Total)> GetPaginatedSinhVienDangOAsync(
    PaginationRequest request,
    string? maSinhVien = null,
    string? hoTen = null,
    string? maPhong = null)
        {
            var today = DateTime.UtcNow.Date;

            var query = from cuTru in DbSet.AsNoTracking()
                        where cuTru.TrangThai == TrangThaiCuTruConstants.DANG_O && cuTru.NgayHetHan >= today
                        join sv in dbFactory.DbContext.Set<SinhVien>().AsNoTracking() on cuTru.SinhVienId equals sv.Id
                        join giuong in dbFactory.DbContext.Set<GiuongKtx>().AsNoTracking() on cuTru.GiuongKtxId equals giuong.Id
                        join phong in dbFactory.DbContext.Set<PhongKtx>().AsNoTracking() on giuong.PhongKtxId equals phong.Id
                        join toa in dbFactory.DbContext.Set<ToaNhaKtx>().AsNoTracking() on phong.ToaNhaId equals toa.Id
                        select new ThongTinSinhVienKtxResponseDto
                        {
                            SinhVienId = sv.Id,
                            MaSinhVien = sv.MaSinhVien ?? "",
                            HoTen = (sv.HoDem + sv.Ten) ?? "",
                            TenToaNha = toa.TenToaNha ?? "",
                            MaPhong = phong.MaPhong ?? "",
                            MaGiuong = giuong.MaGiuong ?? "",
                            TrangThaiGiuong = giuong.TrangThai ?? "",
                            NgayVaoO = cuTru.NgayBatDau,
                            NgayHetHan = cuTru.NgayHetHan
                        };

            if (!string.IsNullOrWhiteSpace(maSinhVien))
                query = query.Where(x => x.MaSinhVien.Contains(maSinhVien.Trim()));

            if (!string.IsNullOrWhiteSpace(hoTen))
                query = query.Where(x => x.HoTen.Contains(hoTen.Trim()));

            if (!string.IsNullOrWhiteSpace(maPhong))
                query = query.Where(x => x.MaPhong.Contains(maPhong.Trim()));

            var total = await query.CountAsync();

            var data = await query
                .OrderByDescending(x => x.HoTen)
                .ThenBy(x => x.TenToaNha)
                .ThenBy(x => x.MaPhong)
                .ThenBy(x => x.MaGiuong)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return (data, total);
        }
    }
}