using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Entities.StudentManagement;

namespace EMS.Domain.Entities
{
    public class BangDiemChiTiet : AuditableEntity
    {
        public required Guid IdSinhVien { get; set; }
        public required Guid IdMonHoc { get; set; }
        public Guid? IdLopHocPhan { get; set; } // LHP SV đã tham gia để có điểm này

        public required decimal DiemTongKet { get; set; }
        public required int LanHoc { get; set; } // Lần học thứ N (1, 2, 3...)

        // Cờ nghiệp vụ - Rất quan trọng cho Học Cải Thiện
        public required bool IsDiemCaoNhat { get; set; }
        // TRUE nếu điểm này là điểm cao nhất, được tính vào GPA/Xếp loại

        public string? GhiChu { get; set; } // Ví dụ: 'Lần 1', 'Học lại', 'Cải thiện'
        public Guid? IdChuyenDoiHocPhan { get; set; }
        public ChuyenDoiHocPhan? ChuyenDoiHocPhan { get; set; }
        public SinhVien? SinhVien { get; set; }
        public MonHoc? MonHoc { get; set; }
        public LopHocPhan? LopHocPhan { get; set; }
    }
}
