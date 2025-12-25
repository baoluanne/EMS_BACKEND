using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class NganhHoc : AuditableEntity
    {
        public required string MaNganhHoc { get; set; }
        public required string TenNganhHoc { get; set; }
        public string TenTiengAnh { get; set; }
        public required string MaTuyenSinh { get; set; }
        public required Guid IdKhoa { get; set; }
        public Khoa? Khoa { get; set; }
        public string? KhoiThi { get; set; }
        public bool? IsVisible { get; set; }
        public string? TenVietTat { get; set; }
        public string? KyTuMaSV { get; set; }
        public Guid? IdKhoiNganh { get; set; }
        public KhoiNganh? KhoiNganh { get; set; }
        public string? GhiChu { get; set; }
    }
}
