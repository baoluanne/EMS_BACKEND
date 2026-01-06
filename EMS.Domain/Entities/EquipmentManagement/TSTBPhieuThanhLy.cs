using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.EquipmentManagement
{
    public class TSTBPhieuThanhLy : AuditableEntity
    {
        public string SoQuyetDinh { get; set; }
        public DateTime NgayThanhLy { get; set; }
        public string LyDo { get; set; }
        public decimal TongTienThuHoi { get; set; }

        public Guid NguoiLapPhieuId { get; set; }
        public virtual NguoiDung NguoiLapPhieu { get; set; }

        public virtual ICollection<TSTBChiTietThanhLy> ChiTietThanhLys { get; set; } = new List<TSTBChiTietThanhLy>();
    }
}
