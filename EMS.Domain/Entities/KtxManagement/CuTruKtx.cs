using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.Domain.Entities.KtxManagement
{
    public class CuTruKtx : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SinhVienId { get; set; }

        [ForeignKey("SinhVienId")]
        public virtual SinhVien SinhVien { get; set; } = null!;
        public Guid GiuongKtxId { get; set; }

        [ForeignKey("GiuongKtxId")]
        public virtual GiuongKtx GiuongKtx { get; set; } = null!;

        public DateTime NgayBatDau { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string TrangThai { get; set; } = "DangO";
        public string? GhiChu { get; set; }
        public Guid? DonKtxId { get; set; }

        [ForeignKey("DonKtxId")]
        public virtual DonKtx? DonKtx { get; set; }
    }
}
