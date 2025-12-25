using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class KeHoachDaoTao_NienChe : AuditableEntity
    {
        public required Guid IdChiTietKhungHocKy_NienChe { get; set; }
        public ChiTietChuongTrinhKhung_NienChe? ChiTietChuongTrinhKhung_NienChe { get; set; }
        public required Guid IdHocKy { get; set; }
        public HocKy? HocKy { get; set; }
        public bool IsHocKyChinh { get; set; }
        public string? GhiChu { get; set; }
    }
} 