using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class ThongTinChung_QuyCheTC : AuditableEntity
    {
        public required Guid IdQuyCheTC { get; set; }
        public required QuyChe_TinChi QuyCheTC { get; set; }
        public decimal? DiemTKTrongSo { get; set; }
        public decimal? DiemGKTrongSo { get; set; }
        public decimal? DiemTieuLuanTrongSo { get; set; }
        public decimal? DiemCuoiKyTrongSo { get; set; }
    }
}
