using EMS.Domain.Enums;

namespace EMS.Application.Services.LopHocPhanServices.Dtos
{
    public class TimKiemLopHocPhanFilterRequestDto
    {
        public string? MaLHP { get; set; }
        public string? TenLopHocPhan  { get; set; }
        public Guid? IdHocKy { get; set; }
        public Guid? IdLopHocPhan { get; set; }
        public Guid? IdKhoaChuQuan { get; set; }

        public Guid? IdCoSo { get; set; }
        public Guid? IdKhoaHoc { get; set; }
        public Guid? IdBacDaoTao { get; set; }

        public Guid? IdLoaiDaoTao { get; set; }
        public Guid? IdNganh { get; set; }
        public Guid? IdChuyenNganh { get; set; }

        public Guid? IdLopDanhNghia { get; set; }
        public string? LopBanDau { get; set; }
        public string? TenMonHoc { get; set; }

        public LoaiLHPEnum? LoaiLHP { get; set; }
        public Guid? IdLoaiMonHoc { get; set; }
        public Guid? IdHinhThucThi { get; set; }

        public LoaiMonLTTHEnum? LoaiMonLTTH { get; set; }
        public TrangThaiLopHocPhanEnum? TrangThaiLHP { get; set; }
        public DateTime? NgayHocCuoiTu { get; set; }
        public DateTime? NgayHocCuoiDen { get; set; }
        public int? Nhom { get; set; }
    }
}
