using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/cu-tru-ktx")]
[ApiController]
public class CuTruKtxController : BaseController<KtxCutru>
{
    private readonly ICuTruKtxService _service;
    public CuTruKtxController(ICuTruKtxService service) : base(service)
    {
        _service = service;
    }

    [HttpGet("hop-dong-hien-tai/{sinhVienId}")]
    public async Task<IActionResult> GetHopDongHienTai(Guid sinhVienId)
    {
        var result = await _service.GetHopDongHienTaiAsync(sinhVienId);
        return result.Match<IActionResult>(
            succ => Ok(succ),
            err => NotFound(new { error = err.Message })
        );
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> GetPaginatedSinhVienDangO(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 30,
        [FromQuery] string? maSinhVien = null,
        [FromQuery] string? hoTen = null,
        [FromQuery] string? maPhong = null)
    {
        var request = new PaginationRequest { Page = page, PageSize = pageSize };
        var result = await _service.GetPaginatedSinhVienDangOAsync(request, maSinhVien, hoTen, maPhong);

        return result.Match<IActionResult>(
            succ => Ok(succ),
            err => BadRequest(new { error = err.Message })
        );
    }

    [HttpPost("sinh-vien-dang-o")]
    public async Task<IActionResult> GetSinhVienDangOAsync(
        [FromBody] PaginationRequest request,
        [FromQuery] string? maSinhVien = null,
        [FromQuery] string? hoTen = null,
        [FromQuery] string? maPhong = null)
    {
        var result = await _service.GetPaginatedSinhVienDangOAsync(request, maSinhVien, hoTen, maPhong);

        return result.Match<IActionResult>(
            succ => Ok(succ),
            err => BadRequest(new { error = err.Message })
        );
    }
}