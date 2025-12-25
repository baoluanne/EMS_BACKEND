using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class HinhThucDaoTao : AuditableEntity
    {
        public required string MaHinhThuc { get; set; }
        public required string TenHinhThuc { get; set; }
        public string? GhiChu { get; set; }
    }
}