using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;
using EMS.Domain.Enums.EquipmentManagement;

namespace EMS.Domain.Entities.EquipmentManagement
{
    public class TSTBChiTietKiemKe : AuditableEntity
    {
        public Guid DotKiemKeId { get; set; }
        public virtual TSTBDotKiemKe DotKiemKe { get; set; }

        public Guid ThietBiId { get; set; }
        public virtual TSTBThietBi ThietBi { get; set; }

        public TrangThaiThietBiEnum TrangThaiSoSach { get; set; }
        public TrangThaiThietBiEnum TrangThaiThucTe { get; set; }
        public bool KhopDot { get; set; }
        public string GhiChu { get; set; }

        public Guid? NguoiKiemKeId { get; set; }
        public virtual NguoiDung NguoiKiemKe { get; set; }
    }
}
