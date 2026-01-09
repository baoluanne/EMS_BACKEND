using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.EquipmentManagement
{
    public class TSTBDotKiemKe : AuditableEntity
    {
        public string? TenDotKiemKe { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public bool? DaHoanThanh { get; set; } = false;
        public string? GhiChu { get; set; }

        public Guid? NguoiBatDauId { get; set; }
        public virtual NguoiDung? NguoiBatDau { get; set; }

        public virtual ICollection<TSTBChiTietKiemKe> ChiTietKiemKes { get; set; } = new List<TSTBChiTietKiemKe>();
    }
}
