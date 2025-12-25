using EMS.Application.Services.NguoiDungServices;
using EMS.Application.Services.NguoiDungServices.Dtos;
using EMS.Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NguoiDungController(INguoiDungService nguoiDungService) : ControllerBase
{
    private readonly INguoiDungService _nguoiDungService = nguoiDungService;

    [HttpPost]
    //[Authorize]
    public async Task<IActionResult> CreateNguoiDungAsync([FromBody] CreateNguoiDungRequestDto request)
    {
        var res = await _nguoiDungService.CreateNguoiDungAsync(request);
        return res.ToResult();
    }

    [HttpGet("/me")]
    [Authorize]
    public async Task<IActionResult> GetMeAsync()
    {
        var res = await _nguoiDungService.GetMeAsync();
        return res.ToResult();
    }
}
