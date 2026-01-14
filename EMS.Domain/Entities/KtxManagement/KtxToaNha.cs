using System;
using System.Collections.Generic;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KTXToaNha : AuditableEntity
    {
        public string? TenToaNha { get; set; }
        public int? LoaiToaNha { get; set; }
        public int? SoTang { get; set; }
        public string? GhiChu { get; set; }

        public virtual ICollection<KtxTang> KtxTangs { get; set; } = new List<KtxTang>();
    }
}