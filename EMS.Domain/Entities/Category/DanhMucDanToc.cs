using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.Category
{
    public class DanhMucDanToc: AuditableEntity
    {
        public required string MaDanToc { get; set; }
        public required string TenDanToc  { get; set; }
        public string? GhiChu { get; set; }
    }
}