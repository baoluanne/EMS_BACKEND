using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxManagement;

[Route("api/tai-san-ktx")]
[ApiController]
public class TaiSanKtxController : BaseController<TaiSanKtx>
{
    private readonly ITaiSanKtxService _service;

    public TaiSanKtxController(ITaiSanKtxService service) : base(service)
    {
        _service = service;
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] Guid? phongKtxId = null,
        [FromQuery] string? tinhTrang = null,
        [FromQuery] string? searchTerm = null)
    {
        var result = await _service.GetPaginatedAsync(request, phongKtxId, tinhTrang, searchTerm);
        return result.Match<IActionResult>(
            succ => Ok(succ),
            err => BadRequest(new { error = err.Message })
        );
    }

    [HttpPost("tao-tai-san")]
    public async Task<IActionResult> Create([FromBody] CreateTaiSanKtxDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.CreateTaiSanAsync(dto);
        return result.Match<IActionResult>(
            succ => Ok(new { id = succ }),
            err => BadRequest(new { error = err.Message })
        );
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTaiSanKtxDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.UpdateTaiSanAsync(dto);
        return result.Match<IActionResult>(
            succ => Ok(new { success = succ }),
            err => BadRequest(new { error = err.Message })
        );
    }
}