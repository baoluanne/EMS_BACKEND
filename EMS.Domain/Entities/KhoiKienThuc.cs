using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class KhoiKienThuc : AuditableEntity
    {
        public required string MaKhoiKienThuc { get; set; }
        public required string TenKhoiKienThuc { get; set; }
        public int? STT { get; set; }
        public string? GhiChu { get; set; }
    }
}
