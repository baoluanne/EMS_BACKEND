using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities;

public class ChungChi : AuditableEntity
{
    public string TenLoaiChungChi { get; set; } = string.Empty;
    
    public string? KyHieu { get; set; }
    public decimal? GiaTri { get; set; }
    public decimal? HocPhi { get; set; }
    public decimal? LePhiThi { get; set; }
    public decimal? ThoiHan { get; set; }
    public decimal? DiemQuyDinh { get; set; }
    public string? GhiChu { get; set; }

    // Navigation properties
    public required Guid IdLoaiChungChi { get; set; }
    public LoaiChungChi? LoaiChungChi { get; set; }
}  