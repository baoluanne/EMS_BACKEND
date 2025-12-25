using System.ComponentModel.DataAnnotations;

namespace EMS.Application.DTOs.Financial
{
    public class AddKhoanThuDto
    {
        [Required(ErrorMessage = "Vui lòng chọn sinh viên")]
        public Guid SinhVienId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn học kỳ")]
        public Guid NamHocHocKyId { get; set; }

        public DateTime? HanNop { get; set; }
        public string? GhiChu { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Cần ít nhất 1 khoản thu")]
        public List<CongNoChiTietInputDto> ChiTiets { get; set; } = new();
    }

    public class CongNoChiTietInputDto
    {
        [Required]
        public Guid LoaiKhoanThuId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Số tiền phải lớn hơn 0")]
        public decimal SoTien { get; set; }

        public string? GhiChu { get; set; }
    }

    public class CongNoDetailDto
    {
        public Guid Id { get; set; }
        public Guid SinhVienId { get; set; }
        public string TenSinhVien { get; set; } = string.Empty;
        public string MaSinhVien { get; set; } = string.Empty;
        public string TenHocKy { get; set; } = string.Empty;
        public DateTime HanNop { get; set; }
        public string GhiChu { get; set; } = string.Empty;
        public decimal TongPhaiThu { get; set; }
        public decimal DaThu { get; set; }
        public decimal TongMienGiam { get; set; }
        public decimal ConNo { get; set; }

        public string TrangThai => ConNo <= 0 ? "Hoàn thành" : "Chưa hoàn thành";
        public List<CongNoChiTietViewDto> ChiTiets { get; set; } = new();
    }

    public class CongNoChiTietViewDto
    {
        public Guid Id { get; set; }
        public Guid LoaiKhoanThuId { get; set; }
        public string TenKhoanThu { get; set; } = string.Empty;
        public decimal SoTien { get; set; }
        public string? GhiChu { get; set; }
    }

    public class MienGiamViewDto
    {
        public string TenChinhSach { get; set; } = string.Empty;
        public decimal SoTienGiam { get; set; }
    }

    public class CongNoViewDto
    {
        public Guid Id { get; set; }
        public string MaSinhVien { get; set; } = string.Empty;
        public string TenSinhVien { get; set; } = string.Empty;
        public string TenHocKy { get; set; } = string.Empty;
        public decimal TongPhaiThu { get; set; }
        public decimal DaThu { get; set; }
        public decimal ConNo { get; set; }
        public string TrangThai { get; set; } = string.Empty;
    }

    public class CreatePhieuThuDto
    {
        [Required]
        public Guid SinhVienId { get; set; }

        public Guid? CongNoId { get; set; }

        [Range(1000, double.MaxValue, ErrorMessage = "Số tiền tối thiểu 1000đ")]
        public decimal SoTien { get; set; }

        public string HinhThucThanhToan { get; set; } = "ChuyenKhoan";

        public string? GhiChu { get; set; }

        public bool XuatHoaDon { get; set; } = false;
        public string? NhaCungCapHoaDon { get; set; }
        public List<PhieuThuChiTietDto>? ChiTiets { get; set; }
    }

    public class PhieuThuHistoryDto
    {
        public Guid Id { get; set; }
        public string SoPhieu { get; set; } = string.Empty;
        public DateTime NgayThu { get; set; }
        public decimal SoTien { get; set; }
        public string HinhThucThanhToan { get; set; } = string.Empty;
        public string? GhiChu { get; set; }
        public bool CoHoaDon { get; set; }
    }

    public class PhieuThuChiTietDto
    {
        // Thêm trường này để khớp với JSON yêu cầu ("idcongnochitiet")
        public Guid? IdCongNoChiTiet { get; set; }
        public Guid LoaiKhoanThuId { get; set; }
        public decimal SoTien { get; set; }
        public string? GhiChu { get; set; }
    }
    public class MienGiamFilterDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Keyword { get; set; }
        public Guid? NamHocHocKyId { get; set; }
        public string? TrangThai { get; set; } // "ChoDuyet", "DaDuyet", "TuChoi"
    }

    // --- DTO Kết quả phân trang (Tự định nghĩa để tránh lỗi PaginationResponse) ---
    public class MienGiamPagedResult
    {
        public List<MienGiamSinhVienDto> Data { get; set; } = new();
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => PageSize > 0 ? (int)Math.Ceiling(TotalRecords / (double)PageSize) : 0;
    }

    // --- DTO Hiển thị ---
    public class MienGiamSinhVienDto
    {
        public Guid Id { get; set; }
        public Guid SinhVienId { get; set; }
        public string MaSinhVien { get; set; } = string.Empty;
        public string TenSinhVien { get; set; } = string.Empty;
        public Guid ChinhSachMienGiamId { get; set; }
        public string TenChinhSach { get; set; } = string.Empty;
        public Guid NamHocHocKyId { get; set; }
        public string TenHocKy { get; set; } = string.Empty;
        public decimal SoTien { get; set; }
        public string TrangThai { get; set; } = string.Empty;
        public string? LyDo { get; set; }
        public DateTime NgayTao { get; set; }
    }

    // --- DTO Tác vụ ---
    public class ApplyMienGiamDto
    {
        [Required]
        public Guid SinhVienId { get; set; }
        [Required]
        public Guid ChinhSachMienGiamId { get; set; }
        [Required]
        public Guid NamHocHocKyId { get; set; }
        public string? LyDo { get; set; }
    }

    public class ApprovalMienGiamDto
    {
        [Required]
        public Guid Id { get; set; }
        public bool IsApproved { get; set; }
        public string? LyDoTuChoi { get; set; }
    }

    public class ChinhSachMienGiamDto
    {
        public Guid Id { get; set; }
        public string TenChinhSach { get; set; } = string.Empty;
        public string LoaiChinhSach { get; set; } = "SoTien"; // "PhanTram" hoặc "SoTien"
        public decimal GiaTri { get; set; }
        public string ApDungCho { get; set; } = "TatCa"; // "TatCa", "DoiTuong", "Lop", "Nganh", "SinhVien"
        public Guid? DoiTuongId { get; set; }
        public Guid? NamHocHocKyId { get; set; }
        public string? TenDot { get; set; } // Tên học kỳ (nếu có)
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string TrangThai { get; set; } = "HoatDong"; // "HoatDong", "TamNgung", "HetHieuLuc"
        public string? GhiChu { get; set; }
        public DateTime NgayTao { get; set; }
    }

    public class CreateChinhSachMienGiamDto
    {
        [Required(ErrorMessage = "Tên chính sách bắt buộc")]
        [MaxLength(200)]
        public string TenChinhSach { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string LoaiChinhSach { get; set; } = "SoTien";

        [Range(0.01, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0")]
        public decimal GiaTri { get; set; }

        [Required]
        [MaxLength(30)]
        public string ApDungCho { get; set; } = "TatCa";

        public Guid? DoiTuongId { get; set; }
        public Guid? NamHocHocKyId { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        [MaxLength(1000)]
        public string? GhiChu { get; set; }
    }

    public class UpdateChinhSachMienGiamDto : CreateChinhSachMienGiamDto
    {
        // Thêm các trường nếu cần update đặc biệt, nhưng giữ giống Create để đơn giản
    }

    public class PagedChinhSachMienGiamResult
    {
        public List<ChinhSachMienGiamDto> Data { get; set; } = new List<ChinhSachMienGiamDto>();
        public int Total { get; set; }
    }



}