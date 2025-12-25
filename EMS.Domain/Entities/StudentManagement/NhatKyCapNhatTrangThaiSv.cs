using EMS.Domain.Entities.Base;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities.StudentManagement
{
    public class NhatKyCapNhatTrangThaiSv: AuditableEntity
    {
        public Guid IdSinhVien { get; set; }
        public SinhVien? SinhVien { get; set; }
        public TrangThaiSinhVienEnum TrangThaiCu { get; set; }
        public TrangThaiSinhVienEnum TrangThaiMoi { get; set; }
        public required string SoQuyetDinh { get; set; }
        public required DateTime NgayQuyetDinh { get; set; }
        public Guid IdQuyetDinh { get; set; }
        public QuyetDinh? QuyetDinh { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public string? GhiChu { get; set; }
    }
}