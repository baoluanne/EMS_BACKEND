using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxCutru : AuditableEntity
    {
        public Guid SinhVienId { get; set; }
        [ForeignKey("SinhVienId")]
        public virtual SinhVien SinhVien { get; set; } = null!;

        public Guid GiuongKtxId { get; set; }
        [ForeignKey("GiuongKtxId")]
        public virtual KtxGiuong GiuongKtx { get; set; } = null!;

        public Guid DonKtxId { get; set; }
        [ForeignKey("DonKtxId")]
        public virtual KtxDon DonKtx { get; set; } = null!;

        public DateTime NgayBatDau { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string TrangThai { get; set; } = "DangO"; // DangO, DaRa
        public string? GhiChu { get; set; }
    }
}