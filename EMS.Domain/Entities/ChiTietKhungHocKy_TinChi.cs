using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class ChiTietKhungHocKy_TinChi : AuditableEntity
    {
        public bool IsBatBuoc { get; set; }
        public required Guid IdChuongTrinhKhung { get; set; }
        public ChuongTrinhKhungTinChi? ChuongTrinhKhungTinChi { get; set; }
        public required Guid IdMonHocBacDaoTao { get; set; }
        public MonHocBacDaoTao? MonHocBacDaoTao { get; set; }
        public required int HocKy { get; set; }
    }
}