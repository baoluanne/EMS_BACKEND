using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class DanhMucKhoanChi: AuditableEntity
    {
        public required string MaKhoanChi { get; set; }
        public required string TenKhoanChi { get; set; }
        public int? STT  { get; set; }
        public string? GhiChu { get; set; }
    }
}