using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.ClassManagement
{
    public class LopHoc : AuditableEntity
    {
        // Basic info
        public required string MaLop { get; set; }
        public required string TenLop { get; set; }
        public string? TenTiengAnh { get; set; }
        public required int SiSoDuKien { get; set; }
        public int SiSoHienTai { get; set; }
        public int SiSoDangHoc { get; set; }
        public bool IsVisible { get; set; }
        public string? GhiChu { get; set; }
        // Foreign keys
        public Guid IdCoSoDaoTao { get; set; }
        public Guid IdKhoaHoc { get; set; }
        public Guid IdBacDaoTao { get; set; }
        public Guid IdLoaiDaoTao { get; set; }
        public Guid IdNganhHoc { get; set; }
        public Guid IdChuyenNganh { get; set; }
        public Guid IdKhoa { get; set; }
        public Guid? IdGiangVienChuNhiem { get; set; }
        public Guid? IdCoVanHocTap { get; set; }
        public Guid? IDCaHoc { get; set; }

        // Meta     
        public string? KyTuMSSV { get; set; }
        public string? SoHopDong { get; set; }
        public string? SoQuyetDinhThanhLapLop { get; set; }
        public DateTime? NgayHopDong { get; set; }
        public DateTime? NgayRaQuyetDinh { get; set; }

        // Navigation properties
        public CoSoDaoTao? CoSoDaoTao { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }
        public BacDaoTao? BacDaoTao { get; set; }
        public LoaiDaoTao? LoaiDaoTao { get; set; }

        public NganhHoc? NganhHoc { get; set; }
        public ChuyenNganh? ChuyenNganh { get; set; }
        public Khoa? Khoa { get; set; }
        public GiangVien? GiangVienChuNhiem { get; set; }
        public GiangVien? CoVanHocTap { get; set; }
        public CaHoc? CaHoc { get; set; }

        public virtual ICollection<LopHocPhan_LopDuKien> LopHocPhanDuKiens { get; set; } = new List<LopHocPhan_LopDuKien>();
    }
}
