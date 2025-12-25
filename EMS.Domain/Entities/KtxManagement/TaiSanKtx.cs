using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.KtxManagement
{
    public class TaiSanKtx : AuditableEntity
    {
        public Guid Id { get; set; }
        public string MaTaiSan { get; set; } = string.Empty;
        public string TenTaiSan { get; set; } = string.Empty;
        public string TinhTrang { get; set; } = "Tot";
        public decimal GiaTri { get; set; }
        public string? GhiChu { get; set; }

        public Guid PhongKtxId { get; set; }
        [ForeignKey("PhongKtxId")]
        public virtual PhongKtx? PhongKtx { get; set; }

        public virtual ICollection<YeuCauSuaChua> YeuCauSuaChuas { get; set; } = new List<YeuCauSuaChua>();
    }
}