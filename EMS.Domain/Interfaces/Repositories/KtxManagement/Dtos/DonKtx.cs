using System;
using System.ComponentModel.DataAnnotations;

namespace EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos
{
    public class DonKtxCreateDto
    {
        [Required] public Guid IdSinhVien { get; set; }
        [Required] public string LoaiDon { get; set; } = string.Empty;

        [Required] public DateTime NgayBatDau { get; set; }
        public DateTime? NgayHetHan { get; set; }

        public string? Ghichu { get; set; }
        public Guid? PhongHienTai { get; set; }
        public Guid? phongMuonChuyen { get; set; }
        public string? LyDoChuyen { get; set; }
    }

    public class DonKtxResponseDto
    {
        public Guid Id { get; set; }
        public string MaDon { get; set; } = string.Empty;
        public Guid SinhVienId { get; set; }
        public string MaSinhVien { get; set; } = string.Empty;
        public string HoTenSinhVien { get; set; } = string.Empty;
        public string LoaiDon { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;
        public DateTime NgayGuiDon { get; set; }
        public string? LyDo { get; set; }
        public string? GhiChuDuyet { get; set; }
        public string? MaPhongHienTai { get; set; }
        public string? MaPhongMuonChuyen { get; set; }
        public string? MaPhongDuocDuyet { get; set; }

        public DateTime NgayBatDauMongMuon { get; set; }
        public DateTime? NgayHetHanMongMuon { get; set; }

        public DateTime? NgayBatDauHienTai { get; set; }
        public DateTime? NgayHetHanHienTai { get; set; }
    }

    public class DonKtxPagingResponse
    {
        public List<DonKtxResponseDto> Data { get; set; } = new();
        public int Total { get; set; }
    }
}