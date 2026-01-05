using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.EquipmentManagement
{
    public class BaoCaoThietBi : AuditableEntity
    {
        public string TenBaoCao { get; set; }
        public string LoaiBaoCao { get; set; }
        public DateTime NgayTaoBaoCao { get; set; }
        public DateTime? NgayKetThucKyBaoCao { get; set; }
        public string DuLieuBaoCao { get; set; }

        public Guid NguoiTaoBaoCaoId { get; set; }
        public virtual NguoiDung NguoiTaoBaoCao { get; set; }
    }
}
