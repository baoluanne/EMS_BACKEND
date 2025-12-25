using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class Khoa : AuditableEntity
    {
        public required string MaKhoa { get; set; }
        public required string TenKhoa { get; set; }
        public string? GhiChu { get; set; }
    }
}
