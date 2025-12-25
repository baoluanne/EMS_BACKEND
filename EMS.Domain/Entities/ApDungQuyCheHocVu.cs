using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class ApDungQuyCheHocVu : AuditableEntity
    {
        public required Guid IdKhoaHoc { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }
        
        public required Guid IdBacDaoTao { get; set; }
        public BacDaoTao? BacDaoTao { get; set; }

        public required Guid IdLoaiDaoTao { get; set; }
        public LoaiDaoTao? LoaiDaoTao { get; set; }
        public Guid? IdQuyCheTC { get; set; } // Check require in logic
        public QuyChe_TinChi? QuyCheTC { get; set; }
        public Guid? IdQuyCheNC { get; set; } // Check require in logic
        public QuyChe_NienChe? QuyCheNC { get; set; }
        public decimal ChoPhepNoMon { get; set; }
        public decimal ChoPhepNoDVHT { get; set; }
        public string? GhiChu { get; set; }
    }
}
