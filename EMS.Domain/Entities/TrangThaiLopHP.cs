using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class TrangThaiLopHP : AuditableEntity
    {
        public required string MaTrangThaiLop { get; set; }
        public required string TenTrangThaiLop { get; set; }
        public int? STT { get; set; }
        public string? GhiChu { get; set; }
    }
}
