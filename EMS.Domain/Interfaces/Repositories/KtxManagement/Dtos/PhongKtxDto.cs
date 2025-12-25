using System.ComponentModel.DataAnnotations;

namespace EMS.Domain.Entities.KtxManagement
{
    public class CreatePhongKtxRequestDto
    {
        [Required]
        public string MaPhongNhapTay { get; set; }

        [Required]
        public Guid ToaNhaId { get; set; }

        [Required]
        [Range(4, 12)]
        public int SoLuongGiuong { get; set; }

        [Required]
        public decimal GiaPhong { get; set; }

        public string TrangThai { get; set; } = "HoatDong";

        public int SoTang { get; set; } = 1;
        public int SoThuTuPhong { get; set; } = 1;
        public string Prefix { get; set; } = "";
    }

    public class CreatePhongKtxResponseDto
    {
        public Guid PhongId { get; set; }
        public string MaPhong { get; set; } = string.Empty;
        public List<string> DanhSachMaGiuong { get; set; } = new();
    }

    public class PhongKtxResponseDto
    {
        public string Id { get; set; } = string.Empty;
        public string MaPhong { get; set; } = string.Empty;
        public string ToaNhaId { get; set; } = string.Empty;
        public string TenToaNha { get; set; } = string.Empty;
        public int SoLuongGiuong { get; set; }
        public int SoLuongDaO { get; set; }
        public int SoGiuongTrong => SoLuongGiuong - SoLuongDaO;
        public string TrangThai { get; set; } = string.Empty;
        public decimal GiaPhong { get; set; }
    }

    public class PhongKtxPagingResponse
    {
        public List<PhongKtxResponseDto> data { get; set; } = new();
        public int total { get; set; }
    }
}