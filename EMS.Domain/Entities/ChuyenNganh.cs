using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class ChuyenNganh : AuditableEntity
    {
        public required string MaChuyenNganh { get; set; }
        public required string TenChuyenNganh { get; set; }
        public required Guid IdNganhHoc { get; set; }
        public NganhHoc? NganhHoc { get; set; }
        public string? MaNganhTuQuan { get; set; }
        public string? GhiChu { get; set; }
        public int? STT { get; set; }
        public string? TenVietTat { get; set; }
        public string? TenTiengAnh { get; set; }
        public bool? IsVisible { get; set; }
    }
}
