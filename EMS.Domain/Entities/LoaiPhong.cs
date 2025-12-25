using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class LoaiPhong : AuditableEntity
    {
        public required string MaLoaiPhong { get; set; }
        public required string TenLoaiPhong { get; set; }
        public string? GhiChu { get; set; }
    }
}
