using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories.KtxManagement
{
    public class ViPhamNoiQuyKTXRepository(DbFactory dbFactory) : AuditRepository<ViPhamNoiQuyKTX>(dbFactory), IViPhamNoiQuyKTXRepository
    {
        public async Task<(List<ViPhamNoiQuyKtxResponseDto> Data, int Total)> GetPaginatedWithDetailsAsync(ViPhamFilterRequest request)
        {
            var query = from vp in DbSet.AsNoTracking().Where(x => !x.IsDeleted)
                        join sv in dbFactory.DbContext.Set<SinhVien>().AsNoTracking() on vp.SinhVienId equals sv.Id
                        join giuong in dbFactory.DbContext.Set<GiuongKtx>().AsNoTracking() on sv.Id equals giuong.SinhVienId into gj
                        from giuong in gj.DefaultIfEmpty()
                        join phong in dbFactory.DbContext.Set<PhongKtx>().AsNoTracking() on giuong.PhongKtxId equals phong.Id into pj
                        from phong in pj.DefaultIfEmpty()
                        join toa in dbFactory.DbContext.Set<ToaNhaKtx>().AsNoTracking() on phong.ToaNhaId equals toa.Id into tj
                        from toa in tj.DefaultIfEmpty()
                        select new ViPhamNoiQuyKtxResponseDto
                        {
                            Id = vp.Id,
                            SinhVienId = vp.SinhVienId,
                            MaSinhVien = sv.MaSinhVien ?? "",
                            HoTenSinhVien = (sv.HoDem + " " + sv.Ten).Trim(),
                            NoiDungViPham = vp.NoiDungViPham,
                            HinhThucXuLy = vp.HinhThucXuLy,
                            DiemTru = vp.DiemTru,
                            NgayViPham = vp.NgayViPham,
                            TenToaNha = toa.TenToaNha,
                            MaPhong = phong.MaPhong
                        };

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var search = request.SearchTerm.Trim().ToLower();
                query = query.Where(x => x.MaSinhVien.ToLower().Contains(search) || x.HoTenSinhVien.ToLower().Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(request.MaPhong))
                query = query.Where(x => x.MaPhong.Contains(request.MaPhong.Trim()));

            if (request.TuNgay.HasValue)
                query = query.Where(x => x.NgayViPham >= request.TuNgay.Value);

            if (request.DenNgay.HasValue)
                query = query.Where(x => x.NgayViPham <= request.DenNgay.Value);
            if (!string.IsNullOrWhiteSpace(request.NoiDungViPham))
            {
                query = query.Where(x => x.NoiDungViPham == request.NoiDungViPham.Trim());
            }
            var total = await query.CountAsync();
            var data = await query
                .OrderByDescending(v => v.NgayViPham)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return (data, total);
        }
    }
}