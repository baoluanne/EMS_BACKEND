using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos
{
    public class GiuongKtxResponseDto
    {
        public Guid Id { get; set; }
        public string MaGiuong { get; set; } = string.Empty;
        public Guid PhongKtxId { get; set; }
        public string MaPhong { get; set; } = string.Empty;
        public string TenToaNha { get; set; } = string.Empty;
        public Guid? SinhVienId { get; set; }
        public string? TenSinhVien { get; set; }
        public string TrangThai { get; set; } = string.Empty;
    }

    public class GiuongKtxPagingResponse
    {
        public List<GiuongKtxResponseDto> Data { get; set; } = new();
        public int Total { get; set; }
    }
    public class UpdateGiuongKtxDto
    {
        public string MaGiuong { get; set; }
        public Guid PhongKtxId { get; set; }
        public string TrangThai { get; set; }
    }
}
