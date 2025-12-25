using EMS.Application.Services.AuthServices.Mappers;
using EMS.Domain.Common;
using EMS.Domain.Constants;
using EMS.Domain.Entities;
using LanguageExt.Pipes;
using Microsoft.AspNetCore.Identity;

namespace EMS.Application.Services.AuthServices;

public partial class AuthService
{
    private PasswordVerificationResult VerifyLogin(NguoiDung nguoiDung, string password)
    {
        return _passwordHasher.VerifyHashedPassword(nguoiDung, nguoiDung.HashedPassword, password);
    }

    private static string GenerateAccessToken(NguoiDung nguoiDung)
    {
        var jwtModel = AuthMapper.ToJwtModel(nguoiDung);

        var accessToken = JwtHelpers.GenerateToken(
            jwtModel,
            expireTimeInHour: AppJwtConstants.AccessTokenExpireTimeInHour
        );

        return accessToken;
    }

    private static string GenerateRefreshToken(NguoiDung nguoiDung)
    {
        var jwtModel = AuthMapper.ToJwtModel(nguoiDung);

        var refreshToken = JwtHelpers.GenerateToken(
            jwtModel,
            key: Env.GetJwtRefreshKey(),
            expireTimeInHour: AppJwtConstants.RefreshTokenExpireTimeInMin
        );

        return refreshToken;
    }

    private void UpdateNguoiDungPassword(NguoiDung nguoiDung, string password)
    {
        nguoiDung.HashedPassword = _passwordHasher.HashPassword(nguoiDung, password);
        _nguoiDungRepository.Update(nguoiDung);
    }
}
