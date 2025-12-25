using EMS.Application.Services.NguoiDungServices.Dtos;

namespace EMS.Application.Services.AuthServices.Dtos;

public class DangNhapResponseDto
{
    public required NguoiDungDto NguoiDung { get; set; }
    public required string AccessToken {  get; set; }
    public required string RefreshToken { get; set; }
}
