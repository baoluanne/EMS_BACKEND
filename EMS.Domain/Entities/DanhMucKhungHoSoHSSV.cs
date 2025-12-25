using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class DanhMucKhungHoSoHSSV : AuditableEntity
    {
        public required Guid IdBacDaoTao { get; set; }
        public BacDaoTao? BacDaoTao { get; set; }

        public required Guid IdLoaiDaoTao { get; set; }
        public LoaiDaoTao? LoaiDaoTao { get; set; }

        public required Guid IdHoSoHSSV { get; set; }
        public DanhMucHoSoHSSV? HoSoHSSV { get; set; }

        public int? STT { get; set; }
        public bool? IsBatBuoc { get; set; }
        public string? GhiChu { get; set; }
        public Guid? IdTieuChiTuyenSinh { get; set; }
        public TieuChiTuyenSinh? TieuChiTuyenSinh { get; set; }
        public Guid? IdKhoaHoc { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }
        public Guid? IdLoaiSinhVien { get; set; }
        public LoaiSinhVien? LoaiSinhVien { get; set; }
    }
}