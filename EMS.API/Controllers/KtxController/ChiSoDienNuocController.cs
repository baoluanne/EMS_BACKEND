using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxManagement
{
    [Route("api/chi-so-dien-nuoc")]
    [ApiController]
    public class ChiSoDienNuocController : BaseController<ChiSoDienNuoc>
    {
        private readonly IChiSoDienNuocService _service;

        public ChiSoDienNuocController(IChiSoDienNuocService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPaginated(
            [FromQuery] PaginationRequest request,
            [FromQuery] Guid? toaNhaId = null,
            [FromQuery] Guid? phongId = null,
            [FromQuery] int? thang = null,
            [FromQuery] int? nam = null,
            [FromQuery] bool? daChot = null)
        {
            var result = await _service.GetPaginatedAsync(request, toaNhaId, phongId, thang, nam, daChot);

            return result.Match<IActionResult>(
                succ => Ok(new { success = true, data = succ.Data, total = succ.Total }),
                err => StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi lấy danh sách chỉ số điện nước",
                    error = err.Message
                })
            );
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] CalculationRequest request)
        {
            if (request == null || request.DienMoi < request.DienCu || request.NuocMoi < request.NuocCu)
                return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ" });

            var result = _service.CalculateConsumption(
                request.DienCu, request.DienMoi, request.NuocCu, request.NuocMoi);

            return Ok(new { success = true, data = result });
        }
    }

    public class CalculationRequest
    {
        public double DienCu { get; set; }
        public double DienMoi { get; set; }
        public double NuocCu { get; set; }
        public double NuocMoi { get; set; }
    }
}