using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.Category
{
    public class DanhMucTonGiao: AuditableEntity
    {
        public required string MaTonGiao { get; set; }
        public required string TenTonGiao { get; set; }
        public string? GhiChu { get; set; }
    }
}