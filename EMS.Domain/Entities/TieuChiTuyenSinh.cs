using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class TieuChiTuyenSinh : AuditableEntity
    {
        public required string MaTieuChi { get; set; } = null!;
        public required string TenTieuChi { get; set; } = null!;
        public string? GhiChu { get; set; }
    }
}
