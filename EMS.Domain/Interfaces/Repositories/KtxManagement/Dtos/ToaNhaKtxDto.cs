namespace EMS.Application.DTOs.KtxManagement;

public class ToaNhaKtxResponseDto
{
    public Guid Id { get; set; }
    public string TenToaNha { get; set; } = string.Empty;
    public string? LoaiToaNha { get; set; }
    public int SoPhong { get; set; }
}

public class ToaNhaKtxPagingResponse
{
    public List<ToaNhaKtxResponseDto> Data { get; set; } = new();
    public int Total { get; set; }
}

public class ToaNhaFilter
{
    public string? TenToaNha { get; set; }
    public string? LoaiToaNha { get; set; }
}