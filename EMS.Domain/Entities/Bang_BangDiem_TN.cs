using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class Bang_BangDiem_TN : AuditableEntity
    {
        public required string MaBang_BangDiem { get; set; }
        public required string TenBang_BangDiem { get; set; }
        public string? GhiChu { get; set; }
    }
} 