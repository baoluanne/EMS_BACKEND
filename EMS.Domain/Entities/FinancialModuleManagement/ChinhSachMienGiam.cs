using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.FinancialModuleManagement
{
    [Table("ChinhSachMienGiam")]
    public class ChinhSachMienGiam : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string TenChinhSach { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string LoaiChinhSach { get; set; } = "SoTien"; 
        [Range(0.01, 1000000000)]
        public decimal GiaTri { get; set; }
        [Required]
        [MaxLength(30)]
        public string ApDungCho { get; set; } = "TatCa";
        public Guid? DoiTuongId { get; set; }
        public Guid? NamHocHocKyId { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        [MaxLength(30)]
        public string TrangThai { get; set; } = "HoatDong";
        [MaxLength(1000)]
        public string? GhiChu { get; set; }
        [ForeignKey("NamHocHocKyId")]
        public virtual NamHoc_HocKy? NamHocHocKy { get; set; }
        public virtual ICollection<MienGiamSinhVien> DanhSachApDung { get; set; }
            = new List<MienGiamSinhVien>();
    }
}