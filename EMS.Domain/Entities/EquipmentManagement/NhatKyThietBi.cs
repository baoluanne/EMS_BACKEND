using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.EquipmentManagement
{
    public class NhatKyThietBi : AuditableEntity
    {
        public Guid ThietBiId { get; set; }
        public virtual ThietBi ThietBi { get; set; }

        public DateTime ThoiGian { get; set; }
        public string HanhDong { get; set; }
        public Guid? NguoiThucHienId { get; set; }
        public virtual NguoiDung NguoiThucHien { get; set; }
        public string MoTaChiTiet { get; set; }
    }
}
