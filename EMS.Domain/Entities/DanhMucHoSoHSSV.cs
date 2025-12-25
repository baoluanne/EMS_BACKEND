using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class DanhMucHoSoHSSV: AuditableEntity
    {
        public required string MaHoSo { get; set; }
        public required string TenHoSo { get; set; }
        public int? STT { get; set; }
        public string? GhiChu { get; set; }
    }
}