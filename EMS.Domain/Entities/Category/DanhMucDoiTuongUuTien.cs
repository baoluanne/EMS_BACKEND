using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.Category
{
    public class DanhMucDoiTuongUuTien: AuditableEntity
    {
        public required string MaDoiTuong { get; set; }
        public required string TenDoiTuong { get; set; }
        public string? GhiChu { get; set; }
    }
}