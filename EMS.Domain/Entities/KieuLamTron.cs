using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class KieuLamTron : AuditableEntity
    {
        public required string MaKieuLamTron { get; set; }
        public required string TenKieuLamTron { get; set; }
        public string? GhiChu { get; set; }
    }
} 