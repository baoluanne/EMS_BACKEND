using EMS.Domain.Entities.Base;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities
{
    public class HoSoSV : AuditableEntity
    {
        public required string MaHoSo { get; set; }
        public required string TenHoSo { get; set; }
        public LoaiHoSoEnum LoaiHoSo { get; set; } = LoaiHoSoEnum.BatBuoc;
        public string? GhiChu { get; set; }
    }
}