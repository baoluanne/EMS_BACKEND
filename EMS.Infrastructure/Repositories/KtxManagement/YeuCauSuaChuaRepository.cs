using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories.KtxManagement;

public class YeuCauSuaChuaRepository(DbFactory dbFactory)
    : AuditRepository<YeuCauSuaChua>(dbFactory), IYeuCauSuaChuaRepository
{
    public async Task<(List<YeuCauSuaChuaResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(
        PaginationRequest request,
        Guid? phongKtxId = null,
        Guid? sinhVienId = null,
        string? trangThai = null,
        string? searchTerm = null)
    {
        var query = DbSet.AsNoTracking()
            .Include(y => y.SinhVien)
            .Include(y => y.PhongKtx).ThenInclude(p => p.ToaNha)
            .Include(y => y.TaiSanKtx)
            .Where(y => !y.IsDeleted);

        if (phongKtxId.HasValue)
            query = query.Where(y => y.PhongKtxId == phongKtxId.Value);

        if (sinhVienId.HasValue)
            query = query.Where(y => y.SinhVienId == sinhVienId.Value);

        if (!string.IsNullOrWhiteSpace(trangThai))
            query = query.Where(y => y.TrangThai == trangThai);

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var term = searchTerm.Trim().ToLower();
            query = query.Where(y =>
                y.TieuDe.ToLower().Contains(term) ||
                y.NoiDung.ToLower().Contains(term) ||
                (y.GhiChuXuLy != null && y.GhiChuXuLy.ToLower().Contains(term)));
        }

        var total = await query.CountAsync();

        var data = await query
            .OrderByDescending(y => y.NgayGui)
            .Select(y => new YeuCauSuaChuaResponseDto
            {
                Id = y.Id,
                TieuDe = y.TieuDe,
                NoiDung = y.NoiDung,
                TrangThai = y.TrangThai,
                GhiChuXuLy = y.GhiChuXuLy,
                ChiPhiPhatSinh = y.ChiPhiPhatSinh,
                NgayGui = y.NgayGui,
                NgayXuLy = y.NgayXuLy,
                NgayHoanThanh = y.NgayHoanThanh,

                SinhVienId = y.SinhVienId,
                HoTenSinhVien = y.SinhVien != null ? (y.SinhVien.HoDem + " " + y.SinhVien.Ten) : "",

                PhongKtxId = y.PhongKtxId,
                MaPhong = y.PhongKtx != null ? (y.PhongKtx.MaPhong ?? "") : "",
                TenToaNha = y.PhongKtx != null && y.PhongKtx.ToaNha != null
                    ? (y.PhongKtx.ToaNha.TenToaNha ?? "")
                    : "",
                TaiSanKtxId = y.TaiSanKtxId,
                TenTaiSan = y.TaiSanKtx != null ? (y.TaiSanKtx.TenTaiSan ?? "") : "",
                MaTaiSan = y.TaiSanKtx != null ? (y.TaiSanKtx.MaTaiSan ?? "") : ""
            })
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return (data, total);
    }
}