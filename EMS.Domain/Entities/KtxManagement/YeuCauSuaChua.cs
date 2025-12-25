using System;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.Domain.Entities.KtxManagement
{
    public class YeuCauSuaChua : AuditableEntity
    {
        public Guid Id { get; set; }
        public string TieuDe { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;
        public string TrangThai { get; set; } = "MoiGui"; // MoiGui, DangXuLy, DaXong, Huy
        public string? KetQuaXuLy { get; set; }
        public decimal ChiPhiPhatSinh { get; set; }
        public DateTime NgayGui { get; set; }
        public DateTime? NgayHoanThanh { get; set; }

        public Guid SinhVienId { get; set; }
        [ForeignKey("SinhVienId")]
        public virtual SinhVien? SinhVien { get; set; }

        public Guid PhongKtxId { get; set; }
        [ForeignKey("PhongKtxId")]
        public virtual PhongKtx? PhongKtx { get; set; }

        public Guid? TaiSanKtxId { get; set; }
        [ForeignKey("TaiSanKtxId")]
        public virtual TaiSanKtx? TaiSanKtx { get; set; }
    }
}