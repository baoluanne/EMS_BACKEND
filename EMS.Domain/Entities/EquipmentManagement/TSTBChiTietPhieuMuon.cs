using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.EquipmentManagement
{
    public class TSTBChiTietPhieuMuon : AuditableEntity
    {
        public Guid PhieuMuonTraId { get; set; }
        public virtual TSTBPhieuMuonTra PhieuMuonTra { get; set; }

        public Guid ThietBiId { get; set; }
        public virtual TSTBThietBi ThietBi { get; set; }

        public string TinhTrangKhiMuon { get; set; }
        public string TinhTrangKhiTra { get; set; }
        public string GhiChuChiTiet { get; set; }
    }
}
