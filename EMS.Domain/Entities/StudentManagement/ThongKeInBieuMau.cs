using System.ComponentModel.DataAnnotations;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.StudentManagement
{
    public class ThongKeInBieuMau: AuditableEntity
    {
        public Guid IdSinhVien { get; set; }
        public SinhVien? SinhVien { get; set; }
        public Guid IdBieuMau { get; set; }
        public DanhMucBieuMau? BieuMau { get; set; }
        public string? MayIn { get; set; }
        public DateTime? NgayIn { get; set; }
        public Guid? IdNguoiIn { get; set; }
        public NguoiDung? NguoiIn { get; set; }
        public string? GhiChu { get; set; }
    }
}