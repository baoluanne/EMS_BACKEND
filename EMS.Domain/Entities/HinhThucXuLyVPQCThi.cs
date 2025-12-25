using System;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities;

public class HinhThucXuLyVPQCThi : AuditableEntity
{
    public string MaHinhThucXL { get; set; }
    public string TenHinhThucXL { get; set; }
    public decimal? PhanTramDiemTru { get; set; }
    public decimal? DiemTruRL { get; set; }
    public MucDoViPham? MucDo { get; set; }
    public Guid IdMucDo { get; set; }
    public string? GhiChu { get; set; }
} 