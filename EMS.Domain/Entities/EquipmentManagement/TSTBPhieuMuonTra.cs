using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Enums.EquipmentManagement;

namespace EMS.Domain.Entities.EquipmentManagement
{
    public class TSTBPhieuMuonTra : AuditableEntity
    {
        public string MaPhieu { get; set; }
        public LoaiDoiTuongMuonEnum LoaiDoiTuong { get; set; }

        public Guid? SinhVienId { get; set; }
        public virtual SinhVien SinhVien { get; set; }

        public Guid? GiangVienId { get; set; }
        public virtual GiangVien GiangVien { get; set; }

        public Guid? NguoiDuyetId { get; set; }
        public virtual NguoiDung NguoiDuyet { get; set; }

        public Guid? NguoiTraId { get; set; }
        public virtual NguoiDung NguoiTra { get; set; }

        public DateTime NgayMuon { get; set; }
        public DateTime NgayTraDuKien { get; set; }
        public DateTime? NgayTraThucTe { get; set; }

        public string LyDoMuon { get; set; }
        public TrangThaiPhieuMuonEnum TrangThai { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<TSTBChiTietPhieuMuon> ChiTietPhieuMuons { get; set; } = new List<TSTBChiTietPhieuMuon>();
    }
}
