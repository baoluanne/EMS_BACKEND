using System;

namespace EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos
{
    public class ThongTinSinhVienKtxResponseDto
    {
        public Guid SinhVienId { get; set; }

        public string MaSinhVien { get; set; } = string.Empty;

        public string HoTen { get; set; } = string.Empty;

        public string Lop { get; set; } = string.Empty;

        public string ChuyenNganh { get; set; } = string.Empty;

        // Bạn có thể thêm các trường khác nếu cần (giới tính, ngày sinh, khoa, v.v.)
        // public string GioiTinh { get; set; } = string.Empty;
        // public DateTime? NgaySinh { get; set; }

        public string TenToaNha { get; set; } = string.Empty;

        public string MaPhong { get; set; } = string.Empty;

        public string MaGiuong { get; set; } = string.Empty;

        public string TrangThaiGiuong { get; set; } = string.Empty;

        public DateTime? NgayVaoO { get; set; }

        public DateTime? NgayHetHan { get; set; }
    }

    public class ThongTinSinhVienKtxPagingResponse
    {
        public List<ThongTinSinhVienKtxResponseDto> Data { get; set; } = new();

        public int Total { get; set; }
    }
}