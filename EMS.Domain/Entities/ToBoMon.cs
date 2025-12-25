using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class ToBoMon : AuditableEntity
    {
        public required string MaToBoMon { get; set; }
        public required string TenToBoMon { get; set; }
        public required Guid IdKhoa { get; set; }
        public required Khoa Khoa { get; set; }
        public string? GhiChu { get; set; }
    }
}
