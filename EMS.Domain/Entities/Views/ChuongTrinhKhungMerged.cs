using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.Views;

public class ChuongTrinhKhungMerged : AuditableEntity
{
    public string? MaChuongTrinh { get; set; }
    public string? TenChuongTrinh { get; set; }
    public bool IsBlock { get; set; }
    public string? GhiChu { get; set; }
    public string? GhiChuTiengAnh { get; set; }

    public Guid IdCoSoDaoTao { get; set; }
    public Guid IdKhoaHoc { get; set; }
    public Guid IdLoaiDaoTao { get; set; }
    public Guid IdNganhHoc { get; set; }
    public Guid IdBacDaoTao { get; set; }
    public Guid IdChuyenNganh { get; set; }

    // true = NienChe, false = TinChi
    public bool IsNienChe { get; set; }
}
