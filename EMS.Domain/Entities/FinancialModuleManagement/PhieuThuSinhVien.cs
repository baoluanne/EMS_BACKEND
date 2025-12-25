using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.Domain.Entities.FinancialModuleManagement
{
    public class PhieuThuSinhVien : AuditableEntity
    {
        public Guid Id { get; set; }
        public string SoPhieu { get; set; } = null!; 
        public Guid SinhVienId { get; set; }
        public Guid? CongNoId { get; set; } 

        public decimal SoTien { get; set; }
        public DateTime NgayThu { get; set; } = DateTime.UtcNow;
        public string HinhThucThanhToan { get; set; } = "ChuyenKhoan"; 
        public string? NguoiThu { get; set; }
        public string? GhiChu { get; set; }
        public bool DaHuy { get; set; } = false; 

        public SinhVien SinhVien { get; set; } = null!;
        public CongNoSinhVien? CongNo { get; set; }
        public HoaDonDienTuSinhVien? HoaDonDienTu { get; set; }
    }
}