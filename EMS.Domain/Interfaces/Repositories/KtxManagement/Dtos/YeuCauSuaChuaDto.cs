using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos
{
    public class YeuCauSuaChuaResponseDto
    {
        public Guid Id { get; set; }
        public string TieuDe { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;
        public string TrangThai { get; set; } = "ChoXuLy"; // ChoXuLy, DangXuLy, HoanThanh, TuChoi
        public string? GhiChuXuLy { get; set; }
        public DateTime? NgayXuLy { get; set; }
        public Guid SinhVienId { get; set; }
        public string HoTenSinhVien { get; set; } = string.Empty;
        public Guid PhongKtxId { get; set; }
        public string MaPhong { get; set; } = string.Empty;
        public string TenToaNha { get; set; } = string.Empty;
        public Guid? TaiSanKtxId { get; set; }
        public string? TenTaiSan { get; set; }
    }

    public class CreateYeuCauSuaChuaDto
    {
        public string TieuDe { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;
        public Guid SinhVienId { get; set; }
        public Guid PhongKtxId { get; set; }
        public Guid? TaiSanKtxId { get; set; }
    }

    public class UpdateYeuCauSuaChuaDto
    {
        public Guid Id { get; set; }
        public string? TrangThai { get; set; }
        public string? GhiChuXuLy { get; set; }
        public DateTime? NgayXuLy { get; set; }
    }

    public class YeuCauSuaChuaPagingResponse
    {
        public List<YeuCauSuaChuaResponseDto> Data { get; set; } = new();
        public int Total { get; set; }
    }
}
