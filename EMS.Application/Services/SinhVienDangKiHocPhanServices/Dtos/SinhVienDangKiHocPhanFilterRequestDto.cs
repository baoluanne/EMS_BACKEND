using EMS.Domain.Enums;

namespace EMS.Application.Services.SinhVienDangKiHocPhanServices.Dtos
{
    public class SinhVienDangKiHocPhanFilterRequestDto
    {
        public Guid? IdHocKy { get; set; }
        public Guid? IdLopHocPhan { get; set; }
        public string? MaLHP { get; set; }
        public string? TenLHP { get; set; }
        public List<TrangThaiDangKyLHP>? TrangThaiDangKyLHP { get; set; }
        public TrangThaiSinhVienEnum? TrangThaiSinhVien { get; set; }
        public bool? HocPhi { get; set; }
        public int? Nhom { get; set; }
    }
}
