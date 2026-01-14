using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxGiuong : AuditableEntity
    {
        public string? MaGiuong { get; set; }

        public Guid? SinhVienId { get; set; }
        [ForeignKey("SinhVienId")]
        public virtual SinhVien? SinhVien { get; set; }

        public Guid PhongKtxId { get; set; }
        [ForeignKey("PhongKtxId")]
        public virtual KtxPhong Phong { get; set; } = null!;

        public virtual ICollection<KtxCutru> CuTruKtxs { get; set; } = new List<KtxCutru>();

        [NotMapped]
        public KtxCutru? HopDongHienTai => CuTruKtxs
            .FirstOrDefault(c => c.TrangThai == "DangO" && c.NgayHetHan >= DateTime.UtcNow);
    }
}