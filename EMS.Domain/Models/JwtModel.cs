namespace EMS.Domain.Models;

public class JwtModel
{
    public Guid Id { get; set; }

    public required string Email { get; set; }

    public required string Ten { get; set; }
}
