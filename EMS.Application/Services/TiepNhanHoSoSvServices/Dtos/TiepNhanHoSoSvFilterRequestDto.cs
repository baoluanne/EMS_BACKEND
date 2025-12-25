using EMS.Domain.Enums;

namespace EMS.Application.Services.TiepNhanHoSoSvServices.Dtos
{
    public class TiepNhanHoSoSvFilterRequestDto
    {
        public Guid? IdSinhVien { get; set; }
        public string? MaSinhVien { get; set; }
        public string? TenSinhVien { get; set; }
        public GioiTinhEnum? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public Guid? IdBacDaoTao { get; set; }
        public Guid? IdLoaiDaoTao { get; set; }
        public TrangThaiSinhVienEnum? TrangThai { get; set; }
        public string? LopHoc { get; set; }
    }

    public class ThongKeTiepNhanHoSoSvFilter
    {
        public Guid? IdCoSo { get; set; }
        public Guid? IdKhoaHoc { get; set; }
        public Guid? IdBacDaoTao { get; set; }
        public Guid? IdLoaiDaoTao { get; set; }
        public Guid? IdNganhHoc { get; set; }
        public Guid? IdChuyenNganh { get; set; }
        public Guid? IdLopHoc { get; set; }
        public string? MaSinhVien { get; set; }
        public string? HoTen { get; set; }
        public Guid? IdHoSo { get; set; }
        /// <summary>
        /// Statistical type filter: 1=Complete documents, 2=Missing documents, 3=Not submitted, 4=Has submitted
        /// </summary>
        public int? IdThongKe { get; set; }
        public LoaiHoSoEnum? LoaiHoSo { get; set; }
        public List<TrangThaiHoSoEnum>? TrangThaiHoSo { get; set; }
        public DateTime? NgayTiepNhanHoSoFrom { get; set; }
        public DateTime? NgayTiepNhanHoSoTo { get; set; }
    }
}