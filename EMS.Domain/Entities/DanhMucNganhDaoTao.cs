using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class DanhMucNganhDaoTao: AuditableEntity
    {
        public required string MaNganh { get; set; }
        public required string TenNganh { get; set; }
        public string? TenTiengAnh { get; set; }
        public string? TenVietTat { get; set; }
        public required string MaTuyenSinh { get; set; }
        public string? STT { get; set; }
        public Guid IdKhoa { get; set; }
        public Khoa? Khoa { get; set; }
        public string? KhoiThi { get; set; }
        public string? KyTuMaSV { get; set; }
        public Guid? IdKhoiNganh { get; set; }
        public KhoiNganh? KhoiNganh { get; set; }
        public string? GhiChu { get; set; }
        public bool? IsVisible { get; set; }
    }
}