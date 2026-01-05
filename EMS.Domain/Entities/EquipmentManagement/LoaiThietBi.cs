using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.EquipmentManagement
{
    public class LoaiThietBi : AuditableEntity
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<ThietBi> ThietBis { get; set; } = new List<ThietBi>();
    }
}
