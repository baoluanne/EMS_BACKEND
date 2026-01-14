using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxManagement;

[Route("api/yeu-cau-sua-chua")]
[ApiController]
public class YeuCauSuaChuaController : BaseController<KtxYeuCauSuaChua>
{
    private readonly IYeuCauSuaChuaService _service;

    public YeuCauSuaChuaController(IYeuCauSuaChuaService service) : base(service)
    {
        _service = service;
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] Guid? phongKtxId = null,
        [FromQuery] Guid? sinhVienId = null,
        [FromQuery] string? trangThai = null,
        [FromQuery] string? searchTerm = null)
    {
        var result = await _service.GetPaginatedAsync(request, phongKtxId, sinhVienId, trangThai, searchTerm);

        return result.Match<IActionResult>(
            succ => Ok(succ),
            err => BadRequest(new { error = err.Message })
        );
    }

    [HttpPost("tao-yeu-cau")]
    public async Task<IActionResult> Create([FromBody] CreateYeuCauSuaChuaDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.CreateYeuCauAsync(dto);

        return result.Match<IActionResult>(
            succ => Ok(new { id = succ, message = "Tạo yêu cầu sửa chữa thành công" }),
            err => BadRequest(new { error = err.Message })
        );
    }

    [HttpPut("update-trang-thai/{id}")]
    public async Task<IActionResult> UpdateTrangThai(
        Guid id,
        [FromBody] UpdateYeuCauSuaChuaDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        dto.Id = id;
        var result = await _service.UpdateTrangThaiAsync(dto);

        return result.Match<IActionResult>(
            succ => Ok(new { success = succ, message = "Cập nhật trạng thái thành công" }),
            err => BadRequest(new { error = err.Message })
        );
    }
}