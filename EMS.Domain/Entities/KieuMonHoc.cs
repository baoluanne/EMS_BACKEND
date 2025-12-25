using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class KieuMonHoc : AuditableEntity
    {
        public required string MaKieuMonHoc { get; set; }
        public required string TenKieuMonHoc { get; set; }
        public string? GhiChu { get; set; }
    }
} 