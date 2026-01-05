using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.EquipmentManagement
{
    public class ChiTietThanhLy : AuditableEntity
    {
        public Guid PhieuThanhLyId { get; set; }
        public virtual PhieuThanhLy PhieuThanhLy { get; set; }

        public Guid ThietBiId { get; set; }
        public virtual ThietBi ThietBi { get; set; }

        public decimal GiaTriConLai { get; set; }
        public decimal GiaBan { get; set; }
        public string GhiChu { get; set; }
    }
}
