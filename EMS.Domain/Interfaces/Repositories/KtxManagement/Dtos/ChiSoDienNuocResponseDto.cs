namespace EMS.Application.DTOs.KtxManagement;

public class ChiSoDienNuocResponseDto
{
    public Guid Id { get; set; }
    public string TenToaNha { get; set; } = string.Empty;
    public string MaPhong { get; set; } = string.Empty;
    public string ThangNam { get; set; } = string.Empty; // Combined "Tháng X/Y"
    public double DienCu { get; set; }
    public double DienMoi { get; set; }
    public double TieuThuDien { get; set; }
    public double NuocCu { get; set; }
    public double NuocMoi { get; set; }
    public double TieuThuNuoc { get; set; }
    public bool DaChot { get; set; }
}

public class ChiSoDienNuocPagingResponse
{
    public List<ChiSoDienNuocResponseDto> Data { get; set; } = new();
    public int Total { get; set; }
}

public class ChiSoDienNuocFilter
{
    public int? Thang { get; set; }
    public int? Nam { get; set; }
    public Guid? ToaNhaId { get; set; }
    public Guid? PhongId { get; set; }
    public bool? DaChot { get; set; }
}