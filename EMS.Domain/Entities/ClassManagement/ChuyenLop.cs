using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities.ClassManagement
{
    public class ChuyenLop : AuditableEntity
    {
        public required Guid IdSinhVien { get; set; }
        public SinhVien? SinhVien { get; set; }

        // Lớp cũ
        public required Guid IdLopCu { get; set; }
        public LopHoc? LopCu { get; set; }
        // Lớp mới
        public required Guid IdLopMoi { get; set; }
        public LopHoc? LopMoi { get; set; }

        public string? SoQuyetDinh { get; set; }
        public DateTime? NgayRaQuyetDinh { get; set; }
        public DateTime NgayChuyenLop { get; set; }
        public string? GhiChu { get; set; }
        public PhanLoaiChuyenLopEnum PhanLoaiChuyenLop { get; set; }
        public string? TrichYeu { get; set; }

        public Guid? IdQuyetDinh { get; set; }
        public QuyetDinh? QuyetDinh { get; set; }

        public TrangThaiChuyenLopEnum TrangThaiXuLy { get; set; }
    }
}