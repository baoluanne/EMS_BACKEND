using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.ClassManagement;

namespace EMS.Domain.Entities.StudentManagement
{
    public class SinhVienNganh2 : AuditableEntity
    {
        public Guid IdSinhVien { get; set; }
        public SinhVien? SinhVien { get; set; }
        // khóa học

        public Guid IdKhoaHoc { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }

        // lớp học 2
        public Guid IdLopHoc2 { get; set; }
        public LopHoc? LopHoc2 { get; set; }
        public string? SoQuyetDinh { get; set; }
        public DateTime? NgayQuyetDinh { get; set; }
        public string? NguoiKy { get; set; }

        public string? GhiChu { get; set; }

        [NotMapped]
        public Guid IdKhoaHoc2 { get; set; }
    }
}