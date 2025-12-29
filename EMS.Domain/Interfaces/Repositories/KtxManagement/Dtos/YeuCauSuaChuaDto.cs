using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos
{
    public class CreateYeuCauSuaChuaDto
    {
        public string TieuDe { get; set; } = null!;
        public string NoiDung { get; set; } = null!;
        public Guid SinhVienId { get; set; }
        public Guid PhongKtxId { get; set; }
        public Guid? TaiSanKtxId { get; set; }
        public DateTime NgayGui { get; set; }
    }

    public class UpdateYeuCauSuaChuaDto
    {
        public Guid Id { get; set; }
        public string? TrangThai { get; set; } // MoiGui, DangXuLy, DaXong, Huy
        public string? GhiChuXuLy { get; set; }
        public DateTime? NgayXuLy { get; set; } // Ngày bắt đầu xử lý (khi chuyển sang DangXuLy)
        public DateTime? NgayHoanThanh { get; set; } // Ngày hoàn thành (khi chuyển sang DaXong)
    }

    public class YeuCauSuaChuaResponseDto
    {
        public Guid Id { get; set; }
        public string TieuDe { get; set; } = null!;
        public string NoiDung { get; set; } = null!;
        public string TrangThai { get; set; } = null!;
        public string? GhiChuXuLy { get; set; }
        public decimal ChiPhiPhatSinh { get; set; }
        public DateTime NgayGui { get; set; }
        public DateTime? NgayXuLy { get; set; }
        public DateTime? NgayHoanThanh { get; set; }

        public Guid SinhVienId { get; set; }
        public string HoTenSinhVien { get; set; } = null!;

        public Guid PhongKtxId { get; set; }
        public string MaPhong { get; set; } = null!;
        public string TenToaNha { get; set; } = null!;

        // Tài Sản
        public Guid? TaiSanKtxId { get; set; }
        public string? TenTaiSan { get; set; }
        public string? MaTaiSan { get; set; }
    }

    public class YeuCauSuaChuaPagingResponse
    {
        public List<YeuCauSuaChuaResponseDto> Data { get; set; } = new();
        public int Total { get; set; }
    }
}