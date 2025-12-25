using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class TrangThaiXetQuyUoc : AuditableEntity
    {
        public required string MaTrangThaiXetQuyUoc { get; set; }
        public required string TenTrangThaiXetQuyUoc { get; set; }
        public int? STT { get; set; }
        public string? GhiChu { get; set; }
    }
}
