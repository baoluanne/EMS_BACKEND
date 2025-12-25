using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class KeHoachDaoTao_TinChi : AuditableEntity
    {
        public required Guid IdChiTietKhungHocKy_TinChi { get; set; }
        public ChiTietKhungHocKy_TinChi? ChiTietKhungHocKy_TinChi { get; set; }
        public required Guid IdHocKy { get; set; }
        public HocKy? HocKy { get; set; }
        public bool IsHocKyChinh { get; set; }
        public string? GhiChu { get; set; }
    }
} 