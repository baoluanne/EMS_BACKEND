using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxDonChiTiet : AuditableEntity
    {
        public Guid DonKtxId { get; set; }
        [ForeignKey("DonKtxId")]
        public virtual KtxDon DonKtx { get; set; } = null!;

        public Guid IdDanhMucKhoanThu { get; set; }
        [ForeignKey("IdDanhMucKhoanThu")]
        public virtual DanhMucKhoanThuNgoaiHocPhi DanhMucKhoanThu { get; set; } = null!;

        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string? GhiChu { get; set; }
    }
}
