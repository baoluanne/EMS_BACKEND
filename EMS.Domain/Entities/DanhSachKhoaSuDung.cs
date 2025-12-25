using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class DanhSachKhoaSuDung : AuditableEntity
    {
        public Guid IdPhong { get; set; }
        public PhongHoc PhongHoc { get; set; }
        public Guid IdKhoaSuDung { get; set; }
        public Khoa KhoaSuDung { get; set; }
        public string? GhiChu { get; set; }
    }
}