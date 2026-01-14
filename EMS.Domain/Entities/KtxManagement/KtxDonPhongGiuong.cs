using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxDonPhongGiuong : AuditableEntity
    {
        public Guid DonKtxId { get; set; }
        [ForeignKey("DonKtxId")]
        public virtual KtxDon DonKtx { get; set; } = null!;

        public Guid? PhongHienTaiId { get; set; }
        [ForeignKey("PhongHienTaiId")]
        public virtual KtxPhong? PhongHienTai { get; set; }

        public Guid PhongYeuCauId { get; set; }
        [ForeignKey("PhongYeuCauId")]
        public virtual KtxPhong PhongYeuCau { get; set; } = null!;

        public Guid? PhongDuocDuyetId { get; set; }
        [ForeignKey("PhongDuocDuyetId")]
        public virtual KtxPhong? PhongDuocDuyet { get; set; }

        public Guid? GiuongDuocDuyetId { get; set; }
        [ForeignKey("GiuongDuocDuyetId")]
        public virtual KtxGiuong? GiuongDuocDuyet { get; set; }

        public string? LyDoChuyen { get; set; }
    }
}