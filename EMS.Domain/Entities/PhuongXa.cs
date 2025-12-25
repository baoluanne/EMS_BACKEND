using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class PhuongXa : AuditableEntity
    {
        public required string MaPhuongXa { get; set; }
        public required string TenPhuongXa { get; set; }
        public QuanHuyen? QuanHuyen { get; set; }
        public Guid? IdQuanHuyen { get; set; }
        public string? GhiChu { get; set; }
    }
}
