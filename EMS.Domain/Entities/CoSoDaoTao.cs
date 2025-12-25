using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class CoSoDaoTao : AuditableEntity
    {
        public required string MaCoSo { get; set; }
        public required string TenCoSo { get; set; }
        public string? GhiChu { get; set; }
    }
}
