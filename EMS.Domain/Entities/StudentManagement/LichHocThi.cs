using System.ComponentModel.DataAnnotations;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities.StudentManagement
{
    public class LichHocThi: AuditableEntity
    {
        public Guid IdDotHoc { get; set; }
        public HocKy? DotHoc { get; set; }

        public Guid IdSinhVien { get; set; }
        public SinhVien? SinhVien { get; set; }

        public LoaiLich LoaiLich { get; set; }

        public Guid IdLopHocPhan { get; set; }
        public LopHocPhan? LopHocPhan { get; set; }

        public DateTime? NgayThi { get; set; }
        public string? TenPhong { get; set; }

    }
}