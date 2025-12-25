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
    public class GiuongKtx : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string MaGiuong { get; set; }

        public Guid? SinhVienId { get; set; }

        public Guid PhongKtxId { get; set; }

        public string TrangThai { get; set; }

        [ForeignKey("PhongKtxId")]
        public virtual PhongKtx? PhongKtx { get; set; }

        [ForeignKey("SinhVienId")]
        public virtual SinhVien? SinhVien { get; set; }
        public virtual ICollection<CuTruKtx> CuTruKtxs { get; set; } = new List<CuTruKtx>();

        [NotMapped]
        public CuTruKtx? HopDongHienTai => CuTruKtxs
    .FirstOrDefault(c => c.TrangThai == "DangO" && c.NgayHetHan >= DateTime.UtcNow);
    }
}
