using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class HocVi : AuditableEntity
    {
        public required string MaHocVi { get; set; }
        public required string TenHocVi { get; set; }
        public string? GhiChu { get; set; }
    }
} 