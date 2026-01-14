using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.KtxManagement
{
    public class KtxChiSoDienNuoc : AuditableEntity
    {
        public Guid PhongKtxId { get; set; }
        [ForeignKey("PhongKtxId")]
        public virtual KtxPhong Phong { get; set; } = null!;

        public int Thang { get; set; }
        public int Nam { get; set; }

        public double DienCu { get; set; }
        public double DienMoi { get; set; }
        public double NuocCu { get; set; }
        public double NuocMoi { get; set; }

        public bool DaChot { get; set; }
    }
}