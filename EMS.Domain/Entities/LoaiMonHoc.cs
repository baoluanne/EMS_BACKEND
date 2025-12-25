using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class LoaiMonHoc : AuditableEntity
    {
        public required string MaLoaiMonHoc { get; set; }
        public required string TenLoaiMonHoc { get; set; }
        public string? GhiChu { get; set; }
    }
}
