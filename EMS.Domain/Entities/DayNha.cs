using System;
using System.Collections.Generic;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class DayNha : AuditableEntity
    {
        public required string MaDayNha { get; set; }
        public required string TenDayNha { get; set; }
        public int? SoTang { get; set; }
        public int? SoPhong { get; set; }
        public string? GhiChu { get; set; }
        public Guid IdDiaDiemPhong { get; set; }
        public DiaDiemPhong? DiaDiemPhong { get; set; }
        public ICollection<PhongHoc>? PhongHoc { get; set; }
    }
} 