using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxManagement;

[Route("api/hoa-don-ktx")]
[ApiController]
public class HoaDonKtxController : BaseController<HoaDonKtx>
{
    private readonly IHoaDonKtxService _service;

    public HoaDonKtxController(IHoaDonKtxService service) : base(service)
    {
        _service = service;
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] Guid? phongKtxId = null,
        [FromQuery] int? thang = null,
        [FromQuery] int? nam = null,
        [FromQuery] string? trangThai = null)
    {
        var result = await _service.GetPaginatedAsync(request, phongKtxId, thang, nam, trangThai);
        return result.Match<IActionResult>(
            succ => Ok(succ),
            err => BadRequest(new { error = err.Message })
        );
    }

    [HttpPost("tao-hoa-don")]
    public async Task<IActionResult> Create([FromBody] CreateHoaDonKtxDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.CreateHoaDonAsync(dto);
        return result.Match<IActionResult>(
            succ => Ok(new { id = succ }),
            err => BadRequest(new { error = err.Message })
        );
    }

    [HttpPut("{id}/thanh-toan")]
    public async Task<IActionResult> ThanhToan(Guid id, [FromBody] string? ghiChu = null)
    {
        var result = await _service.ThanhToanHoaDonAsync(id, ghiChu);
        return result.Match<IActionResult>(
            succ => Ok(new { success = succ, message = "Thanh toán hóa đơn thành công" }),
            err => BadRequest(new { error = err.Message })
        );
    }
}