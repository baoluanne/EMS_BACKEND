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
    public class ChiSoDienNuoc : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PhongKtxId { get; set; }

        public int Thang { get; set; }

        public int Nam { get; set; }

        public double DienCu { get; set; }

        public double DienMoi { get; set; }

        public double NuocCu { get; set; }

        public double NuocMoi { get; set; }

        public bool DaChot { get; set; }

        [ForeignKey("PhongKtxId")]
        public virtual PhongKtx? PhongKtx { get; set; }
        public virtual ICollection<HoaDonKtx> HoaDonKtxs { get; set; } = new List<HoaDonKtx>();
    }
}
