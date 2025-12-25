using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class TinhThanh : AuditableEntity
    {
        public required string MaTinhThanh { get; set; }
        public required string TenTinhThanh { get; set; }
        public string? GhiChu { get; set; }
    }
}
