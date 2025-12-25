using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities;

public class LoaiChungChi : AuditableEntity
{
    public string MaLoaiChungChi { get; set; }
    public string TenLoaiChungChi { get; set; }
    public int? STT { get; set; }
    public string? GhiChu { get; set; }
} 