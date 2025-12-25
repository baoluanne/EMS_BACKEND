using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class LoaiHinhGiangDay : AuditableEntity
    {
        public required string MaLoaiHinhGiangDay { get; set; }
        public required string TenLoaiHinhGiangDay { get; set; }
        public int? STT { get; set; }
        public string? GhiChu { get; set; }
    }
}
