using EMS.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EMS.Application.Services.NguoiDungServices.Dtos;

public class CreateNguoiDungRequestDto
{
    [EmailAddress]
    public required string Email { get; set; }

    public required string Ten { get; set; }

    public required string Ho { get; set; }

    public string? TenDiem { get; set; }

    public static NguoiDung ToNguoiDung(CreateNguoiDungRequestDto dto)
    {
        return new NguoiDung
        {
            Email = dto.Email,
            Ten = dto.Ten,
            Ho = dto.Ho,
            TenDem = dto.TenDiem,
            HashedPassword = string.Empty
        };
    }
}
