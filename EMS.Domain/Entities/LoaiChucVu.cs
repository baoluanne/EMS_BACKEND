using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class LoaiChucVu: AuditableEntity
    {
        public required string MaLoaiChucVu { get; set; }
        public required string TenLoaiChucVu { get; set; }
        public int? STT {  get; set; }
        public string? GhiChu { get; set; }
    }
}
