using EMS.Application.Services.ChuongTrinhKhungTinChiServices.Dtos;
using EMS.Domain.Dtos;
using EMS.Domain.Entities;

namespace EMS.Application.Services.ChuongTrinhKhungTinChiServices.Mappers
{
    public class ChuongTrinhKhungTinChiMapper
    {
        public static ChuongTrinhKhungTinChi ToEntity(ChuongTrinhKhungTinChiCreateRequest request)
        {
            var idChuongTrinh = request.Id ?? Guid.NewGuid();
            return new ChuongTrinhKhungTinChi
            {
                Id = idChuongTrinh,
                IdCoSoDaoTao = request.IdCoSoDaoTao,
                IdKhoaHoc = request.IdKhoaHoc,
                IdLoaiDaoTao = request.IdLoaiDaoTao,
                IdNganhHoc = request.IdNganhHoc,
                IdBacDaoTao = request.IdBacDaoTao,
                IdChuyenNganh = request.IdChuyenNganh,
                ChiTietKhungHocKy_TinChis = request.ChiTietKhungHocKyTinChis.Select(detail => new ChiTietKhungHocKy_TinChi
                {
                    Id = Guid.NewGuid(),
                    IdMonHocBacDaoTao = detail.IdMonHocBacDaoTao,
                    HocKy = detail.HocKy,
                    IsBatBuoc = detail.IsBatBuoc,
                    IdChuongTrinhKhung = idChuongTrinh,
                }).ToList()
            };
        }

        public static ChuongTrinhKhungTinChiResponseDto ToDto(ChuongTrinhKhungTinChi entity)
        {
            return new ChuongTrinhKhungTinChiResponseDto
            {
                Id = entity.Id,
                MaChuongTrinh = entity.MaChuongTrinh,
                TenChuongTrinh = entity.TenChuongTrinh,
                IsBlock = entity.IsBlock,
                GhiChu = entity.GhiChu,
                GhiChuTiengAnh = entity.GhiChuTiengAnh,
                IdCoSoDaoTao = entity.IdCoSoDaoTao,
                IdKhoaHoc = entity.IdKhoaHoc,
                IdLoaiDaoTao = entity.IdLoaiDaoTao,
                IdNganhHoc = entity.IdNganhHoc,
                IdBacDaoTao = entity.IdBacDaoTao,
                IdChuyenNganh = entity.IdChuyenNganh,
                
                CoSoDaoTao = entity.CoSoDaoTao,
                KhoaHoc = entity.KhoaHoc,
                LoaiDaoTao = entity.LoaiDaoTao,
                NganhHoc = entity.NganhHoc,
                BacDaoTao = entity.BacDaoTao,
                ChuyenNganh = entity.ChuyenNganh,
                DanhSachLopHoc = new List<LopHocResponseDto>(),
                ChiTietKhungHocKy_TinChis = entity.ChiTietKhungHocKy_TinChis
            };
        }

    }
}
