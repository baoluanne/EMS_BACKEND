using EMS.Domain.Enums;

namespace EMS.Application.Services.SinhVienServices.Dtos
{
    public class TimKiemSinhVienFilterRequestDto
    {
        public Guid? Id { get; set; }

        public string? MaSinhVien { get; set; } = string.Empty;

        public string? HoDem { get; set; }

        public string? Ten { get; set; }

        public string? DiaChi { get; set; }

        public GioiTinhEnum? GioiTinh { get; set; }

        public DateTime? NgaySinhTu { get; set; }

        public DateTime? NgaySinhDen { get; set; }

        public Guid? IdCoSo { get; set; }

        public Guid? IdKhoaHoc { get; set; }

        public Guid? IdBacDaoTao { get; set; }

        public Guid? IdLoaiDaoTao { get; set; }

        public Guid? IdNganh { get; set; }

        public Guid? IdChuyenNganh { get; set; }

        public Guid? IdLopHoc { get; set; }

        public TrangThaiSinhVienEnum? TrangThai { get; set; }
    }

}
