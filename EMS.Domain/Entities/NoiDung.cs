using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities;

public class NoiDung : AuditableEntity
{
    public required string TenNoiDung { get; set; }
}
