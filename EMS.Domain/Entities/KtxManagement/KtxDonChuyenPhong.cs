using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxDonChuyenPhong : AuditableEntity
    {
        public Guid DonKtxId { get; set; }
        public virtual KtxDon DonKtx { get; set; } = null!;

        public Guid PhongHienTaiId { get; set; }
        public virtual KtxPhong PhongHienTai { get; set; } = null!;

        public Guid GiuongHienTaiId { get; set; }
        public virtual KtxGiuong GiuongHienTai { get; set; } = null!;

        public Guid PhongYeuCauId { get; set; }
        public virtual KtxPhong PhongYeuCau { get; set; } = null!;

        public Guid? GiuongYeuCauId { get; set; }
        public virtual KtxGiuong? GiuongYeuCau { get; set; }

        public string? LyDoChuyenPhong { get; set; }
    }
}