using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities;

public class LopNienChe : AuditableEntity
{
    public string MaLop { get; set; }
    public string TenLop { get; set; }
    public bool IsVisible { get; set; }
    public Guid? IdCoSoDaoTao { get; set; }
    public Guid IdBacDaoTao { get; set; }
    public Guid? IdLoaiDaoTao { get; set; }
    public Guid? IdKhoaHoc { get; set; }
    public Guid? IdNganh { get; set; }
    public Guid? IdChuyenNganh { get; set; }

    // Navigation properties
    public CoSoDaoTao? CoSoDaoTao { get; set; }
    public LoaiDaoTao? LoaiDaoTao { get; set; }
    public KhoaHoc? KhoaHoc { get; set; }
    public NganhHoc? NganhHoc { get; set; }
    public ChuyenNganh? ChuyenNganh { get; set; }
} 