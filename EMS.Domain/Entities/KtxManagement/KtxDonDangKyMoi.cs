using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxDonDangKyMoi : AuditableEntity
    {
        public Guid DonKtxId { get; set; }
        [ForeignKey("DonKtxId")]
        public virtual KtxDon DonKtx { get; set; } = null!;

        public Guid PhongYeuCauId { get; set; }
        [ForeignKey("PhongYeuCauId")]
        public virtual KtxPhong PhongYeuCau { get; set; } = null!;

        public Guid? GiuongYeuCauId { get; set; }
        [ForeignKey("GiuongYeuCauId")]
        public virtual KtxGiuong? GiuongYeuCau { get; set; }

        public string? LyDo { get; set; }
    }
}
