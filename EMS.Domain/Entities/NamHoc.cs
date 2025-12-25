using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class NamHoc : AuditableEntity
    {
        public required string NamHocValue { get; set; }
        public required string NienHoc { get; set; }
        public bool IsVisible { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public string? TenTiengAnh { get; set; }
        public float? SoTuan { get; set; }
        public string? GhiChu { get; set; }
    }
}