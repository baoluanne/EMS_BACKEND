using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class PhanMonLopHoc : AuditableEntity
    {
        public required Guid IdMonHocBacDaoTao { get; set; }
        public MonHocBacDaoTao MonHocBacDaoTao { get; set; }
        public required Guid IdLopNienChe { get; set; }
        public LopNienChe LopNienChe { get; set; }
        public required int HocKy { get; set; }
        public bool IsVisible { get; set; }
        public string? GhiChu { get; set; }
    }
}
