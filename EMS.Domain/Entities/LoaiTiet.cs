using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class LoaiTiet : AuditableEntity
    {
        public required string MaLoaiTiet { get; set; }
        public required string TenLoaiTiet { get; set; }
        public decimal? HeSo { get; set; }
        public string? GhiChu { get; set; }
    }
}
