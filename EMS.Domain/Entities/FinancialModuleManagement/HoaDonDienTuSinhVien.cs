using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.FinancialModuleManagement
{
    public class HoaDonDienTuSinhVien : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid PhieuThuId { get; set; }

        public string MaHoaDon { get; set; } = null!; 
        public string? LinkPDF { get; set; }
        public string? LinkXML { get; set; }
        public string NhaCungCap { get; set; } = "MISA";

        public string TrangThai { get; set; } = "ChoPhatHanh";
        public DateTime? NgayPhatHanh { get; set; }

        public PhieuThuSinhVien PhieuThu { get; set; } = null!;
    }
}