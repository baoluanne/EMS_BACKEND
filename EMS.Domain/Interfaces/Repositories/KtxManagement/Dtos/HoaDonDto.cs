namespace EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;

public class HoaDonKtxResponseDto
{
    public Guid Id { get; set; }
    public int Thang { get; set; }
    public int Nam { get; set; }
    public decimal TienDien { get; set; }
    public decimal TienNuoc { get; set; }
    public decimal TongTien { get; set; }
    public string TrangThai { get; set; } = "ChuaThanhToan";
    public DateTime? NgayThanhToan { get; set; }
    public string? GhiChu { get; set; }
    public Guid PhongKtxId { get; set; }
    public string MaPhong { get; set; } = string.Empty;
    public string TenToaNha { get; set; } = string.Empty;
    public Guid? ChiSoDienNuocId { get; set; }
}

public class CreateHoaDonKtxDto
{
    public int Thang { get; set; }
    public int Nam { get; set; }
    public decimal TienDien { get; set; }
    public decimal TienNuoc { get; set; }
    public decimal TongTien { get; set; }
    public Guid PhongKtxId { get; set; }
    public Guid? ChiSoDienNuocId { get; set; }
}

public class UpdateHoaDonKtxDto
{
    public Guid Id { get; set; }
    public string? TrangThai { get; set; }
    public DateTime? NgayThanhToan { get; set; }
    public string? GhiChu { get; set; }
}

public class HoaDonKtxPagingResponse
{
    public List<HoaDonKtxResponseDto> Data { get; set; } = new();
    public int Total { get; set; }
}