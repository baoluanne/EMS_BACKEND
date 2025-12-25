using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.Category
{
    public class DanhMucQuocTich: AuditableEntity
    {
        public required string MaQuocGia { get; set; }
        public required string TenQuocGia { get; set; }
        public string? GhiChu { get; set; }
    }
}