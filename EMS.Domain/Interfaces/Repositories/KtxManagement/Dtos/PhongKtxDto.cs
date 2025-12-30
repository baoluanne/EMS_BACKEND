using System.ComponentModel.DataAnnotations;

namespace EMS.Domain.Entities.KtxManagement
{

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