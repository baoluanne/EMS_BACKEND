using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.Domain.Entities
{
    public class MonHocBacDaoTao : AuditableEntity
    {
        public double? DVHT_TC { get; set; }
        public int? SoTinChi { get; set; }
        public int? SoTietLyThuyet { get; set; }
        public int? SoTietThucHanh { get; set; }
        public int? TuHoc { get; set; }
        public int? SoLanKTDinhKy { get; set; }
        public int? ThucHanh { get; set; }
        public int? LyThuyet { get; set; }
        public int? MoRong { get; set; }
        public int? SoTietLTT { get; set; }
        public int? SoTietTHBT { get; set; }
        public bool? IsLyThuyet { get; set; }
        public string? GhiChu { get; set; }
        public int? SoTietTuHoc { get; set; }
        public int? SoGioThucTap { get; set; }
        public int? SoGioDoAnBTLon { get; set; }
        public int? SoTietKT { get; set; }
        public double? DVHT_HP { get; set; }
        public double? DVHT_Le { get; set; }
        public bool? IsKhongTinhDiemTBC { get; set; }

        // Foreign Keys           
        public Guid? IdMonHoc { get; set; }
        public Guid? IdBacDaoTao { get; set; }
        public Guid? IdHinhThucThi { get; set; }
        public Guid? IdLoaiHinhGiangDay { get; set; }
        public Guid? IdLoaiTiet { get; set; }
        //public Guid? IdQuyUocCotDiem { get; set; }

        // Navigation properties
        public MonHoc? MonHoc { get; set; }
        public BacDaoTao? BacDaoTao { get; set; }
        public HinhThucThi? HinhThucThi { get; set; }
        public LoaiHinhGiangDay? LoaiHinhGiangDay { get; set; }
        public LoaiTiet? LoaiTiet { get; set; }
        public QuyUocCotDiem_NC? QuyUocCotDiem_NC { get; set; }
        public Guid? IdQuyUocCotDiem_NC { get; set; }
        public QuyUocCotDiem_TC? QuyUocCotDiem_TC { get; set; }
        public Guid? IdQuyUocCotDiem_TC { get; set; }

        public ICollection<SinhVienMienMonHoc> SinhVienDuocMiens { get; set; } = new List<SinhVienMienMonHoc>();
    }
}