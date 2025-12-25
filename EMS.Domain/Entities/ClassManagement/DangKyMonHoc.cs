using EMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.Domain.Entities.ClassManagement
{
    public class DangKyMonHoc: AuditableEntity
    {
        public string MaDangKy { get; set; } = string.Empty;
        public Guid IdSinhVien { get; set; }
        public Guid IdMonHoc { get; set; }

        public Guid? IdLopHocPhan { get; set; }
        public Guid IdHocKy { get; set; }
        public Guid IdNamHoc { get; set; }
        public DateTime NgayDangKy { get; set; }
        public TrangThaiDangKy TrangThai { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public Guid? IdNguoiDuyet { get; set; }
        public string? LyDoDuyet { get; set; }
        public int SoTinChi { get; set; }
        public decimal? DiemQuaTrinh { get; set; }
        public decimal? DiemCuoiKy { get; set; }
        public decimal? DiemTongKet { get; set; }
        public string? DiemChu { get; set; }
        public decimal? DiemSo4 { get; set; }
        public bool? KetQua { get; set; }
        public int SoBuoiVang { get; set; } = 0;
        public string? LyDoVang { get; set; }
        public string? GhiChu { get; set; }
        public bool IsMienGiam { get; set; } = false;
        public int LanHoc { get; set; } = 1;
        public decimal? HocPhi { get; set; }
        public bool DaDongHocPhi { get; set; } = false;
        public DateTime? NgayDongHocPhi { get; set; }
        public SinhVien? SinhVien { get; set; }
        public MonHoc? MonHoc { get; set; }
        public LopHocPhan? LopHocPhan { get; set; }
        public HocKy? HocKy { get; set; }
        public NamHoc? NamHoc { get; set; }
        public NguoiDung? NguoiDuyet { get; set; }
    }
}