using EMS.Application.Services.AuthServices.Dtos;
using EMS.Application.Services.CurrentUserServices;
using EMS.Application.Services.NguoiDungServices.Mappers;
using EMS.Domain.Common;
using EMS.Domain.Entities;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;

namespace EMS.Application.Services.AuthServices;

public partial class AuthService(
    IUnitOfWork unitOfWork, 
    IPasswordHasher<NguoiDung> passwordHasher,
    ICurrentUserService currentUserService
) : IAuthService
{
    private readonly IPasswordHasher<NguoiDung> _passwordHasher = passwordHasher;

    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly INguoiDungRepository _nguoiDungRepository = unitOfWork.GetRepository<INguoiDungRepository>();
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task<Result<DangNhapResponseDto>> DangNhapAsync(DangNhapRequestDto request)
    {
        var nguoiDung = await _nguoiDungRepository.GetNguoiDungByEmailAsync(request.Email);
        if (nguoiDung is null)
        {
            return new Result<DangNhapResponseDto>(new NotFoundException("Không tìm thấy người dùng"));
        }

        var passwordVerified = VerifyLogin(nguoiDung, request.Password);
        if (passwordVerified == PasswordVerificationResult.Failed)
        {
            return new Result<DangNhapResponseDto>(new UnauthorizedException("Sai thông tin đăng nhập"));
        }

        var response = new DangNhapResponseDto
        {
            AccessToken = GenerateAccessToken(nguoiDung),
            RefreshToken = GenerateRefreshToken(nguoiDung),
            NguoiDung = NguoiDungMapper.ToNguoiDungDto(nguoiDung)
        };

        return response;
    }

    public async Task<Result<DangNhapResponseDto>> RefreshTokenAsync(RefreshTokenRequestDto request)
    {       
        var principal = JwtHelpers.GetPrincipalFromToken(
            request.Token,
            Env.GetJwtRefreshKey()
        );
        if (principal == null)
        {
            return new Result<DangNhapResponseDto>(new UnauthorizedException("Phiên đăng nhập hết hạn"));
        }

        var nguoiDung = await _currentUserService.GetCurrentUser();
        if (nguoiDung is null)
        {
            return new Result<DangNhapResponseDto>(new NotFoundException("Không tìm thấy người dùng"));
        }

        var response = new DangNhapResponseDto
        {
            AccessToken = GenerateAccessToken(nguoiDung),
            RefreshToken = GenerateRefreshToken(nguoiDung),
            NguoiDung = NguoiDungMapper.ToNguoiDungDto(nguoiDung)
        };

        return response;
    }

    public async Task<Result<bool>> ChangePasswordAsync(ChangePasswordRequestDto request)
    {
        if (request.Password != request.PasswordConfirm)
        {
            return new Result<bool>(new BadRequestException("Mật khẩu và mật khẩu xác nhận không trùng khớp"));
        }

        var nguoiDung = await _currentUserService.GetCurrentUser();
        if (nguoiDung is null)
        {
            return new Result<bool>(new NotFoundException("Không tìm thấy người dùng"));
        }

        var passwordVerified = VerifyLogin(nguoiDung, request.OldPassword);
        if (passwordVerified == PasswordVerificationResult.Failed)
        {
            return new Result<bool>(new UnauthorizedException("Sai thông tin đăng nhập"));
        }

        UpdateNguoiDungPassword(nguoiDung, request.Password);

        await _unitOfWork.CommitAsync();

        return true;
    }
}
