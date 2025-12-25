using System;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities;

public class DanhMucPhongBan : AuditableEntity
{
    public string MaPhongBan { get; set; }
    public string TenPhongBan { get; set; }
    public bool IsDaoTao { get; set; }
} 