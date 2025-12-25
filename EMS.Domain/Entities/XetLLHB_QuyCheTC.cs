using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class XetLLHB_QuyCheTC : AuditableEntity
    {
        public required Guid IdQuyCheHocVu { get; set; }
        public required QuyCheHocVu QuyCheHocVu { get; set; }
        public int? NamThu { get; set; }
        public decimal? TCTichLuyTu { get; set; }
        public decimal? TCTichLuyDen { get; set; }
        public decimal? DiemTBCTichLuy { get; set; }
    }
}
