using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EMS.Domain.Models;

namespace EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos
{
    public class CreateViPhamNoiQuyKtxDto
    {
        [Required] public Guid SinhVienId { get; set; }
        [Required] public string NoiDungViPham { get; set; } = string.Empty;
        public string? HinhThucXuLy { get; set; }
        public int DiemTru { get; set; }
        public DateTime NgayViPham { get; set; } = DateTime.Now;
    }

    public class UpdateViPhamNoiQuyKtxDto : CreateViPhamNoiQuyKtxDto
    {
        [Required] public Guid Id { get; set; }
    }

    public class ViPhamNoiQuyKtxResponseDto
    {
        public Guid Id { get; set; }
        public Guid SinhVienId { get; set; }
        public string MaSinhVien { get; set; } = string.Empty;
        public string HoTenSinhVien { get; set; } = string.Empty;
        public string NoiDungViPham { get; set; } = string.Empty;
        public string? HinhThucXuLy { get; set; }
        public int DiemTru { get; set; }
        public DateTime NgayViPham { get; set; }
        public string? TenToaNha { get; set; }
        public string? MaPhong { get; set; }
    }

    public class ViPhamFilterRequest : PaginationRequest
    {
        public string? SearchTerm { get; set; }
        public string? MaPhong { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public string? NoiDungViPham { get; set; }
    }

    public class ViPhamNoiQuyKtxPagingResponse
    {
        public List<ViPhamNoiQuyKtxResponseDto> Data { get; set; } = new();
        public int Total { get; set; }
    }
}