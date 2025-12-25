  using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class KhoaHoc : AuditableEntity
    {
        public required string TenKhoaHoc { get; set; }
        public string? Nam { get; set; }
        public string? CachViet { get; set; }
        public string? GhiChu { get; set; }
        public bool IsVisible { get; set; }
    }
}
