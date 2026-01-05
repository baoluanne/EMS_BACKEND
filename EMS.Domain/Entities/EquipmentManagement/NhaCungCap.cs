using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.EquipmentManagement
{
    public class NhaCungCap : AuditableEntity
    {
        public string TenNhaCungCap { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string NguoiLienHe { get; set; }
        public string ChucVuNguoiLienHe { get; set; }
        public bool IsActive { get; set; } = true;
        public string GhiChu { get; set; }

        public virtual ICollection<ThietBi> ThietBis { get; set; } = new List<ThietBi>();
        public virtual ICollection<PhieuBaoTri> PhieuBaoTris { get; set; } = new List<PhieuBaoTri>();
    }
}
