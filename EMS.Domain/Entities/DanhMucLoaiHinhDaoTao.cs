using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities;

public class DanhMucLoaiHinhDaoTao : AuditableEntity
{
    public required string MaLoaiDaoTao { get; set; }
    public required string TenLoaiDaoTao { get; set; }
    public string? TenTiengAnh { get; set; }
    public decimal? SoThuTu { get; set; }
    public string? GhiChu {  get; set; }
    public bool? IsVisible { get; set; }
    public string? NoiDung { get; set; }
}
