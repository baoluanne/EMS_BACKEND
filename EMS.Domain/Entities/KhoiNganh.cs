using System.ComponentModel.DataAnnotations;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class KhoiNganh : AuditableEntity
    {
        public required string MaKhoiNganh { get; set; }
        public required string TenKhoiNganh { get; set; }
        public bool IsVisible { get; set; }
        public string? GhiChu { get; set; }
    }
}