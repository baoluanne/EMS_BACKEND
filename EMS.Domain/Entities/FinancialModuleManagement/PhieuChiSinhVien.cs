using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.Domain.Entities.FinancialModuleManagement
{
    [Table("PhieuChiSinhVien")]
    public class PhieuChiSinhVien : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SoPhieu { get; set; } = null!; 

        public Guid SinhVienId { get; set; }

        public decimal SoTien { get; set; }

        [MaxLength(255)]
        public string LyDoChi { get; set; } = null!; 

        public DateTime NgayChi { get; set; } = DateTime.UtcNow;

        [MaxLength(50)]
        public string HinhThucChi { get; set; } = "ChuyenKhoan"; 

        [MaxLength(50)]
        public string? SoTaiKhoanNhan { get; set; }

        [MaxLength(100)]
        public string? NganHangNhan { get; set; }

        [ForeignKey("SinhVienId")]
        public virtual SinhVien SinhVien { get; set; } = null!;
    }
}