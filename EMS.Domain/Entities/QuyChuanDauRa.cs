using System;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class QuyChuanDauRa : AuditableEntity
    {
        public required Guid IdCoSoDaoTao { get; set; }
        public CoSoDaoTao? CoSoDaoTao { get; set; }
        public required Guid IdKhoaHoc { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }
        public required Guid IdBacDaoTao { get; set; }
        public BacDaoTao? BacDaoTao { get; set; }
        public required Guid IdLoaiDaoTao { get; set; }
        public LoaiDaoTao? LoaiDaoTao { get; set; }
        public required Guid IdChungChi { get; set; }
        public ChungChi? ChungChi { get; set; }
        public required Guid IdLoaiChungChi { get; set; }
        public LoaiChungChi? LoaiChungChi { get; set; }
        public Guid? IdChuyenNganh { get; set; }
        public ChuyenNganh? ChuyenNganh { get; set; }
        public string? GhiChu { get; set; }
        public bool IsChuanDauRaBoSung { get; set; }
    }
} 