using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxTang : AuditableEntity
    {
        public Guid ToaNhaId { get; set; }
        [ForeignKey("ToaNhaId")]
        public virtual KTXToaNha ToaNha { get; set; } = null!;

        public string? TenTang { get; set; }
        public string? LoaiTang { get; set; }
        public int? SoLuongPhong { get; set; }

        public virtual ICollection<KtxPhong> KtxPhongs { get; set; } = new List<KtxPhong>();
    }
}