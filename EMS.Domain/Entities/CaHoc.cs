using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities
{
    public class CaHoc : AuditableEntity
    {
        public required string MaCaHoc { get; set; }
        public required string TenCaHoc { get; set; }
        public string? Thu { get; set; }
        public string? Tiet { get; set; }
        public BuoiHoc? BuoiHoc { get; set; }
        public string? GhiChu { get; set; }
    }
}
