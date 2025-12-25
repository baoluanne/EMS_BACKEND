using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class NamHoc_HocKy : AuditableEntity
    {
        public required string TenDot { get; set; }
        public int STT { get; set; }
        public int SoTuan { get; set; }
        public required decimal HeSo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDangKyHP { get; set; }
        public bool IsDangKyNoiTruTT { get; set; }
        public bool IsVisible { get; set; }
        public int? TuThang { get; set; }
        public int? DenThang { get; set; }
        public int? TuNgay { get; set; }
        public int? DenNgay { get; set; }
        public string? TenDayDu { get; set; }
        public string? TenTiengAnh { get; set; }
        public string? NamHoc { get; set; }
        public string? GhiChu { get; set; }
    }
}
