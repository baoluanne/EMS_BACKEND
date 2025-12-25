using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities
{
    public class LoaiKhoanThu : AuditableEntity
    {
        public required string MaLoaiKhoanThu { get; set; }
        public required string TenLoaiKhoanThu { get; set; }
    }
}