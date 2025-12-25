using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class NhomLoaiHanhViViPham : AuditableEntity
    {
        public required string MaNhomHanhVi { get; set; }
        public required  string TenNhomHanhVi { get; set; }
        public string? GhiChu { get; set; }
    }
}