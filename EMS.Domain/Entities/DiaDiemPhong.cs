using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class DiaDiemPhong : AuditableEntity
    {
        public required string MaDDPhong { get; set; }
        public required string TenNhomDDPhong { get; set; }
        public required string DiaChi { get; set; }
        public required Guid IdCoSoDaoTao { get; set; }
        public CoSoDaoTao? CoSoDaoTao { get; set; }
        public string? DiaDiem { get; set; }
        public double? BanKinh { get; set; }
        public string? GhiChu { get; set; }
        public ICollection<DayNha>? DayNha { get; set; }
    }
} 