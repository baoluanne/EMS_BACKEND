using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class LoaiGiangVien : AuditableEntity
    {
        public required string MaLoaiGiangVien { get; set; }
        public required string TenLoaiGiangVien { get; set; }
        public string? GhiChu { get; set; }
    }
} 