using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxYeuCauSuaChua : AuditableEntity
    {
        public string TieuDe { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;
        public string TrangThai { get; set; } = "MoiGui"; // MoiGui, DangXuLy, DaXong, Huy
        public string? GhiChuXuLy { get; set; }
        public decimal ChiPhiPhatSinh { get; set; } = 0;

        public DateTime NgayGui { get; set; } = DateTime.UtcNow;
        public DateTime? NgayXuLy { get; set; }
        public DateTime? NgayHoanThanh { get; set; }

        public Guid SinhVienId { get; set; }
        [ForeignKey("SinhVienId")]
        public virtual SinhVien SinhVien { get; set; } = null!;

        public Guid PhongKtxId { get; set; }
        [ForeignKey("PhongKtxId")]
        public virtual KtxPhong Phong { get; set; } = null!;
    }
}