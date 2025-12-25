using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Entities.StudentManagement;

public class MienGiamSinhVien : AuditableEntity
{
    [Key]
    public Guid Id { get; set; }

    public Guid SinhVienId { get; set; }
    public Guid NamHocHocKyId { get; set; }
    public Guid? CongNoId { get; set; }

    // THÊM DÒNG NÀY - Liên kết tới chính sách
    public Guid ChinhSachMienGiamId { get; set; }

    public decimal SoTien { get; set; }

    [MaxLength(500)]
    public string? LyDo { get; set; }

    [MaxLength(50)]
    public string TrangThai { get; set; } = "ChoDuyet";

    public DateTime? NgayDuyet { get; set; }

    // Navigation
    [ForeignKey("SinhVienId")]
    public virtual SinhVien SinhVien { get; set; } = null!;

    [ForeignKey("NamHocHocKyId")]
    public virtual NamHoc_HocKy NamHocKy { get; set; } = null!;

    [ForeignKey("CongNoId")]
    public virtual CongNoSinhVien? CongNo { get; set; }

    // MỚI: Liên kết với chính sách
    [ForeignKey("ChinhSachMienGiamId")]
    public virtual ChinhSachMienGiam ChinhSachMienGiam { get; set; } = null!;
}