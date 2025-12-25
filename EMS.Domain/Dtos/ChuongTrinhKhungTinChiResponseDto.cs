using EMS.Domain.Entities;

namespace EMS.Domain.Dtos
{
    public class ChuongTrinhKhungTinChiResponseDto
    {
        // Properties from ChuongTrinhKhungTinChi
        public Guid Id { get; set; }
        public string? MaChuongTrinh { get; set; }
        public string? TenChuongTrinh { get; set; }
        public bool IsBlock { get; set; }
        public string? GhiChu { get; set; }
        public string? GhiChuTiengAnh { get; set; }
        public required Guid IdCoSoDaoTao { get; set; }
        public required Guid IdKhoaHoc { get; set; }
        public required Guid IdLoaiDaoTao { get; set; }
        public required Guid IdNganhHoc { get; set; }
        public required Guid IdBacDaoTao { get; set; }
        public required Guid IdChuyenNganh { get; set; }

        // Navigation properties
        public CoSoDaoTao? CoSoDaoTao { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }
        public LoaiDaoTao? LoaiDaoTao { get; set; }
        public NganhHoc? NganhHoc { get; set; }
        public BacDaoTao? BacDaoTao { get; set; }
        public ChuyenNganh? ChuyenNganh { get; set; }

        public ICollection<LopHocResponseDto> DanhSachLopHoc { get; set; } = new List<LopHocResponseDto>();
        public ICollection<ChiTietKhungHocKy_TinChi>? ChiTietKhungHocKy_TinChis { get; set; }
    }
}