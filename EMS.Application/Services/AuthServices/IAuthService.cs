using EMS.Application.Services.AuthServices.Dtos;
using LanguageExt.Common;

namespace EMS.Application.Services.AuthServices;

public interface IAuthService
{
    Task<Result<DangNhapResponseDto>> DangNhapAsync(DangNhapRequestDto request);
    Task<Result<DangNhapResponseDto>> RefreshTokenAsync(RefreshTokenRequestDto request);
    Task<Result<bool>> ChangePasswordAsync(ChangePasswordRequestDto request);
}
