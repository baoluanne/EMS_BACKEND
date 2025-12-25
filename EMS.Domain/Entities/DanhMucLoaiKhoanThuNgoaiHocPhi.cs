using EMS.Domain.Entities.Base;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities
{
    public class DanhMucLoaiKhoanThuNgoaiHocPhi: AuditableEntity
    {
        public required string MaLoaiKhoanThu { get; set; }
        public required string TenLoaiKhoanThu { get; set; }
        public int? STT { get; set; }
        public bool XuatHoaDonDienTu { get; set; }
        public HinhThucThu? HinhThucThu { get; set; }
        public bool PhanBoDoanThu { get; set; }
        public string? MaTKNganHang { get; set; }
    }
}