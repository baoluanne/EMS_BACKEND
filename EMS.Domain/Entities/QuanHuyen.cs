using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class QuanHuyen : AuditableEntity
    {
        public required string MaQuanHuyen { get; set; }
        public required string TenQuanHuyen { get; set; }
        public TinhThanh? TinhThanh { get; set; }
        public Guid? IdTinhThanh { get; set; }
        public string? GhiChu { get; set; }
    }
}
