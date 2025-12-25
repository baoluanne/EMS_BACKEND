using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities;

public class LoaiSinhVien: AuditableEntity
{
    public required string TenLoaiSinhVien {  get; set; }
    public required string MaLoaiSinhVien { get; set; }
}
