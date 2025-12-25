using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class LoaiQuyetDinh: AuditableEntity
    {
        public required string MaLoaiQD { get; set; }
        public required string TenLoaiQD { get; set; }
        public string? GhiChu { get; set; }
        public bool? IsVisible { get; set; }
        public int? STT { get; set; }
    }
}