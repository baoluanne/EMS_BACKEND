using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class MucDoViPham : AuditableEntity
    {
        public required string MaMucDoViPham { get; set; }
        public required string TenMucDoViPham { get; set; }
        public string? GhiChu { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
