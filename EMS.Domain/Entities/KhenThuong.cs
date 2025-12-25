using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class KhenThuong : AuditableEntity
    {
        public required string MaKhenThuong { get; set; }
        public required string TenKhenThuong { get; set; }
        public int? DiemCong { get; set; }
        public int? DiemCongToiDa { get; set; }
        public string? NoiDung { get; set; }
        public string? GhiChu { get; set; }
        public bool IsViPhamNoiTru { get; set; }
        public Guid? IdLoaiKhenThuong { get; set; }
        public LoaiKhenThuong? LoaiKhenThuong { get; set; }
    }
}