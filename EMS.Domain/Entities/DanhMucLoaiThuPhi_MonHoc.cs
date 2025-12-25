using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class DanhMucLoaiThuPhi_MonHoc: AuditableEntity
    {
        public required string MaLoaiThuPhi { get; set; }
        public required string TenLoaiThuPhi { get; set; }
        public int? STT { get; set; }
        public bool? CapSoHoaDonDienTu { get; set; }
        public string? CongThucQuyDoi {  get; set; }
        public string? MaTKNganHang { get; set; }
        public string? GhiChu { get; set; }
    }
}