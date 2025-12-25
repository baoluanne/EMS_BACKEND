using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class NhomLoaiKhenThuong : AuditableEntity
    {
        public required string MaNhomKhenThuong { get; set; }
        public required string TenNhomKhenThuong { get; set; }
        public string? GhiChu { get; set; } 
    }
}