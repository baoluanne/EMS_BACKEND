using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;
using EMS.Domain.Enums.EquipmentManagement;

namespace EMS.Domain.Entities.EquipmentManagement
{
    public class TSTBThietBi : AuditableEntity
    {
        public string? MaThietBi { get; set; }
        public string? TenThietBi { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }
        public string? ThongSoKyThuat { get; set; }
        public int? NamSanXuat { get; set; }
        public DateTime? NgayMua { get; set; }
        public DateTime? NgayHetHanBaoHanh { get; set; }
        public decimal? NguyenGia { get; set; }
        public decimal? GiaTriKhauHao { get; set; }
        public TrangThaiThietBiEnum? TrangThai { get; set; }
        
        public string? GhiChu { get; set; }
        public string? HinhAnhUrl { get; set; }

        public Guid? LoaiThietBiId { get; set; }
        public virtual TSTBLoaiThietBi? LoaiThietBi { get; set; }

        public Guid? NhaCungCapId { get; set; }
        public virtual TSTBNhaCungCap? NhaCungCap { get; set; }

        public Guid? PhongHocId { get; set; }
        public virtual PhongHoc? PhongHoc { get; set; }
        
        public virtual ICollection<TSTBChiTietPhieuMuon> ChiTietPhieuMuons { get; set; } = new List<TSTBChiTietPhieuMuon>();
        public virtual ICollection<TSTBPhieuBaoTri> PhieuBaoTris { get; set; } = new List<TSTBPhieuBaoTri>();
        public virtual ICollection<TSTBChiTietKiemKe> ChiTietKiemKes { get; set; } = new List<TSTBChiTietKiemKe>();
        public virtual ICollection<TSTBChiTietThanhLy> ChiTietThanhLys { get; set; } = new List<TSTBChiTietThanhLy>();
    }
}
