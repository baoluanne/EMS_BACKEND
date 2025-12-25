using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities.StudentManagement
{
    //DT_DangKyHocPhan trong PMT database
    public class SinhVienDangKiHocPhan : AuditableEntity
    {
        public Guid IdSinhVien { get; set; }
        public SinhVien? SinhVien { get; set; }
        public Guid IdLopHocPhan { get; set; }
        public LopHocPhan? LopHocPhan { get; set; }
        //Dùng Enum này để xác định trạng thái/loại hình đăng ký (Mới, Học lại, Cải thiện).
        public TrangThaiDangKyLHP TrangThaiDangKyLHP { get; set; }
        public bool HocPhi { get; set; } = false;
        public NguonDangKyHocPhanEnum? NguonDangKy { get; set; }

        public int? Nhom { get; set; }
        public Guid? IdNguoiDangKy { get; set; }
        public NguoiDung? NguoiDangKy { get; set; }

    }
}