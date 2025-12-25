using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.KtxManagement
{
    public class ToaNhaKtx : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? TenToaNha { get; set; }
        public string? LoaiToaNha { get; set; }

        public virtual ICollection<PhongKtx> PhongKtxs { get; set; } = new List<PhongKtx>();
    }
}
