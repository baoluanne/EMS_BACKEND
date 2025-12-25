using System;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class ChiTietChuongTrinhKhung_NienChe : AuditableEntity
    {
        public bool IsBatBuoc { get; set; }
        public Guid IdChuongTrinhKhung { get; set; }
        public ChuongTrinhKhungNienChe? ChuongTrinhKhungNienChe { get; set; }
        public required Guid IdMonHocBacDaoTao { get; set; }
        public MonHocBacDaoTao? MonHocBacDaoTao { get; set; }
        public required int HocKy { get; set; }
    }
}   