using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class LoaiKhenThuong : AuditableEntity
    {
        public required string TenLoaiKhenThuong { get; set; }
        public required   string MaLoaiKhenThuong { get; set; }
        public int? DiemCongToiDa { get; set; }
        public string? GhiChu { get; set; }
        public NhomLoaiKhenThuong NhomLoaiKhenThuong { get; set; }
        public Guid IdNhomLoaiKhenThuong { get; set; }
        public ICollection<KhenThuong> KhenThuongs { get; set; }
    }
}