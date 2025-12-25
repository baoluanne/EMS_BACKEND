using EMS.Domain.Enums;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.Domain.Entities.ClassManagement
{
    public class PhanChuyenNganh : AuditableEntity
    {
        public Guid IdSinhVien { get; set; }
        public Guid? IdChuyenNganhCu { get; set; }
        public Guid IdChuyenNganhMoi { get; set; }
        public Guid IdHocKy { get; set; }
        public Guid IdNamHoc { get; set; }
        public LoaiPhanChuyenNganh LoaiPhanChuyen { get; set; }
        public DateTime NgayPhanChuyen { get; set; } = DateTime.UtcNow;
        public string LyDoPhanChuyen { get; set; } = string.Empty;
        public TrangThaiPhanChuyenNganh TrangThai { get; set; } = TrangThaiPhanChuyenNganh.ChoDuyet;
        public Guid? IdNguoiDuyet { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public string? LyDoTuChoi { get; set; }
        public decimal? DiemXet { get; set; }
        public int? ThuTuUuTien { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public string? GhiChu { get; set; }
        // Navigation Properties
        public SinhVien? SinhVien { get; set; }
        public ChuyenNganh? ChuyenNganhCu { get; set; }
        public ChuyenNganh? ChuyenNganhMoi { get; set; }
        public HocKy? HocKy { get; set; }
        public NamHoc? NamHoc { get; set; }
        public NguoiDung? NguoiDuyet { get; set; }
    }
}