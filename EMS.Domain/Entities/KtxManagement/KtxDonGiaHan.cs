using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxDonGiaHan : AuditableEntity
    {
        public Guid DonKtxId { get; set; }
        [ForeignKey("DonKtxId")]
        public virtual KtxDon DonKtx { get; set; } = null!;

        public Guid PhongHienTaiId { get; set; }
        [ForeignKey("PhongHienTaiId")]
        public virtual KtxPhong PhongHienTai { get; set; } = null!;

        public Guid GiuongHienTaiId { get; set; }
        [ForeignKey("GiuongHienTaiId")]
        public virtual KtxGiuong GiuongHienTai { get; set; } = null!;

        public string? LyDo { get; set; }
    }
}
