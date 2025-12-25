using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class HocKy : AuditableEntity
    {
        public required Guid IdNamHoc { get; set; }
        public NamHoc? NamHoc { get; set; }
        public required string TenDot { get; set; }
        public required int SoThuTu { get; set; }
        public int? SoTuan { get; set; }
        public double? HeSo { get; set; }
        public int? TuThang { get; set; }
        public int? DenThang { get; set; }
        public string? NamHanhChinh { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public string? TenDayDu { get; set; }
        public string? TenTiengAnh { get; set; }
        public string? GhiChu { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
        public bool IsDKHP { get; set; }
        public bool IsDKNTTT { get; set; }

        //Cần thiết cho chức năng Hủy đăng ký (Kiểm tra thời hạn).
        public DateTime? NgayBatDauHuyDK { get; set; }
        public DateTime? NgayKetThucHuyDK { get; set; }
    }
}