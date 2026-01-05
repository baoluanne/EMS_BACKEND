using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;
using EMS.Domain.Enums.EquipmentManagement;

namespace EMS.Domain.Entities.EquipmentManagement
{
    public class PhieuBaoTri : AuditableEntity
    {
        public string MaPhieu { get; set; }

        public Guid ThietBiId { get; set; }
        public virtual ThietBi ThietBi { get; set; }

        public Guid? NhaCungCapId { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }

        public Guid NguoiLapPhieuId { get; set; }
        public virtual NguoiDung NguoiLapPhieu { get; set; }

        public Guid? NguoiXuLyId { get; set; }
        public virtual NguoiDung NguoiXuLy { get; set; }

        public LoaiBaoTriEnum LoaiBaoTri { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string NoiDungBaoTri { get; set; }
        public string KetQuaXuLy { get; set; }
        public decimal ChiPhi { get; set; }
        public string GhiChu { get; set; }
        public string HinhAnhUrl { get; set; }
    }

}
