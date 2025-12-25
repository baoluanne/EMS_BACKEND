using EMS.API.Controllers.Base;
using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxManagement
{
    [ApiController]
    [Route("api/[controller]")]
    [Route("api/phong-ktx")]
    public class PhongKtxController : BaseController<PhongKtx>
    {
        private readonly IPhongKtxService _service;

        public PhongKtxController(IPhongKtxService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("tao-phong-moi")]
        public async Task<IActionResult> TaoPhongMoi([FromBody] CreatePhongKtxRequestDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _service.TaoPhongMoiAsync(request);

            return result.Match<IActionResult>(
                Succ: dto => Ok(dto),
                Fail: err => BadRequest(new { error = err.Message })
            );
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPaginated(
    [FromQuery] PaginationRequest request,
    [FromQuery] string? maPhong = null,
    [FromQuery] string? toaNhaId = null,
    [FromQuery] string? trangThai = null)
        {
            var result = await _service.GetPaginatedAsync(request, maPhong, toaNhaId, trangThai);

            return result.Match<IActionResult>(
                success => Ok(success),
                fail => BadRequest(new { error = fail.Message })
            );
        }
    }
}