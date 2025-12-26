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
        public string? GhiChuXuLy { get; set; }
        public decimal ChiPhiPhatSinh { get; set; } = 0;

        public DateTime NgayGui { get; set; } = DateTime.UtcNow;

        public DateTime? NgayXuLy { get; set; }

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
        public Guid? HoaDonKtxId { get; set; }
        [ForeignKey(nameof(HoaDonKtxId))]
        public virtual HoaDonKtx? HoaDonKtx { get; set; }
    }
}