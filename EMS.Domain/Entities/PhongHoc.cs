using System;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class PhongHoc : AuditableEntity
    {
        public required string MaPhong { get; set; }
        public required string TenPhong { get; set; }
        public int? SoBan { get; set; }
        public int? SoChoNgoi { get; set; }
        public int? SoChoThi { get; set; }
        public bool? IsNgungDungMayChieu { get; set; }
        public string? GhiChu { get; set; }
        public required Guid IdDayNha { get; set; }
        public DayNha? DayNha { get; set; }
        public Guid IdTCMonHoc { get; set; }
        public TinhChatMonHoc? TCMonHoc { get; set; }
        public required Guid IdLoaiPhong { get; set; }
        public LoaiPhong? LoaiPhong { get; set; }
    }
} 