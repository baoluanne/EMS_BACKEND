using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities;

public class NguoiDung : AuditableEntity
{
    public required string Email { get; set; }

    public required string Ten { get; set; }

    public required string Ho { get; set; }

    public string? TenDem { get; set; }

    public required string HashedPassword { get; set; }

    [NotMapped]
    public string? FullName
    {
        get
        {
            var fullName = Ho;
            if (!string.IsNullOrWhiteSpace(TenDem))
                fullName += $" {TenDem}";
            if (!string.IsNullOrWhiteSpace(Ten))
                fullName += $" {Ten}";
            return fullName ?? Email;
        }
    }
}