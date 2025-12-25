namespace EMS.Application.Services.GiangVienServices.Dtos
{
    public class GiangVienImportDto
    {
        public string MaGiangVien { get; set; } = string.Empty;
        public string HoDem { get; set; } = string.Empty;
        public string Ten { get; set; } = string.Empty;
        public DateTime? NgaySinh { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string? Email { get; set; }

        public string TenLoaiGiangVien { get; set; } = string.Empty;
        public string TenKhoa { get; set; } = string.Empty;

        public string? TenVietTat { get; set; }
        public decimal? HSGV_LT { get; set; }
        public decimal? HSGV_TH { get; set; }
        public string? PhuongTien { get; set; }
        public DateTime? NgayChamDutHopDong { get; set; }
        public bool? IsCoiThi { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsKhongChamCong { get; set; }
        public bool? IsChamDutHopDong { get; set; }

        public string? TenHocVi { get; set; }
        public string? TenToBoMon { get; set; }
    }

}
