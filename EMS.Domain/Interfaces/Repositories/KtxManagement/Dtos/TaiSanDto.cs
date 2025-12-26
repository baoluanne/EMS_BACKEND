using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos
{
    public class TaiSanKtxResponseDto
    {
        public Guid Id { get; set; }
        public string MaTaiSan { get; set; } = string.Empty;
        public string TenTaiSan { get; set; } = string.Empty;
        public string TinhTrang { get; set; } = "Tot";
        public decimal GiaTri { get; set; }
        public string? GhiChu { get; set; }
        public Guid PhongKtxId { get; set; }
        public string MaPhong { get; set; } = string.Empty;
        public string TenToaNha { get; set; } = string.Empty;
    }

    public class CreateTaiSanKtxDto
    {
        public string MaTaiSan { get; set; } = string.Empty;
        public string TenTaiSan { get; set; } = string.Empty;
        public string TinhTrang { get; set; } = "Tot";
        public decimal GiaTri { get; set; }
        public string? GhiChu { get; set; }
        public Guid PhongKtxId { get; set; }
    }

    public class UpdateTaiSanKtxDto : CreateTaiSanKtxDto
    {
        public Guid Id { get; set; }
    }

    public class TaiSanKtxPagingResponse
    {
        public List<TaiSanKtxResponseDto> Data { get; set; } = new();
        public int Total { get; set; }
    }
}
