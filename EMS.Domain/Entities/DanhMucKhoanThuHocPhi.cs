using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class DanhMucKhoanThuHocPhi: AuditableEntity
    {
        public required string MaKhoanThu { get; set; }
        public required string TenKhoanThu { get; set; }
        public int? STT  { get; set; }
        public bool CapSoHoaDonDienTu { get; set; }
        public string? GhiChu { get; set; }
    }
}