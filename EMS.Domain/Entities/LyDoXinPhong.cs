using System;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities;

public class LyDoXinPhong : AuditableEntity
{
    public string MaLoaiXinPhong { get; set; }
    public string TenLoaiXinPhong { get; set; }
    public int? SoThuTu { get; set; }
} 