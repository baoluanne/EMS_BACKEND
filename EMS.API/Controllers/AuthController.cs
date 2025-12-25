using EMS.Application.Services.AuthServices;
using EMS.Application.Services.AuthServices.Dtos;
using EMS.Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> DangNhapAsync([FromBody] DangNhapRequestDto request)
    {
        var res = await _authService.DangNhapAsync(request);
        return res.ToResult();
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenRequestDto request)
    {
        var res = await _authService.RefreshTokenAsync(request);
        return res.ToResult();
    }

    [HttpPut("password")]
    [Authorize]
    public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordRequestDto request)
    {
        var res = await _authService.ChangePasswordAsync(request);
        return res.ToResult();
    }
}
