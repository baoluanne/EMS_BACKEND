using EMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.ClassManagement;

namespace EMS.Domain.Entities.StudentManagement
{
    /// <summary>
    /// Chuyển trường - Quản lý việc đăng ký chuyển trường của sinh viên
    /// </summary>
    public class ChuyenTruong: AuditableEntity
    {
        public required string MaHoSo { get; set; }
        public string? HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public GioiTinhEnum? GioiTinh { get; set; }
        public Guid? IdCoSo { get; set; }
        public CoSoDaoTao? CoSo { get; set; }

        public Guid? IdKhoaHoc { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }
        public Guid? IdBacDaoTao { get; set; }
        public BacDaoTao? BacDaoTao { get; set; }
        public Guid? IdLoaiDaoTao { get; set; }
        public LoaiDaoTao? LoaiDaoTao { get; set; }
        public Guid? IdNganhHoc { get; set; }
        public NganhHoc? NganhHoc { get; set; }

        // thông tin nhâp trường mới
        public Guid? IdSinhVien { get; set; }
        public SinhVien? SinhVien { get; set; }
        public bool TuTaoMaSinhVien { get; set; } = true;
        public Guid IdChuyenNganh { get; set; }
        public ChuyenNganh? ChuyenNganh { get; set; }
        public Guid IdLopHoc { get; set; }
        public LopHoc? LopHoc { get; set; }
    }
}