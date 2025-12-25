namespace EMS.Application.Services.NguoiDungServices.Dtos;

public class NguoiDungDto
{
    public Guid Id { get; set; }

    public required string Email { get; set; }

    public required string Ten { get; set; }

    public required string Ho { get; set; }

    public string? TenDiem { get; set; }
}
