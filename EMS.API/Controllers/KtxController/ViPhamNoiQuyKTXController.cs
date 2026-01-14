using Microsoft.AspNetCore.Mvc;
using EMS.API.Controllers.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Application.Services.KtxService;
using EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos;

namespace EMS.API.Controllers.KtxManagement
{
    [Route("api/vi-pham-noiquy-ktx")]
    [ApiController]
    public class ViPhamNoiQuyKTXController(IViPhamNoiQuyKTXService service) : BaseController<KtxViPhamNoiQuy>(service)
    {
        [HttpGet("pagination")]
        public async Task<IActionResult> GetPaginated([FromQuery] ViPhamFilterRequest request)
        {
            var result = await service.GetPaginatedAsync(request);
            return result.Match<IActionResult>(
                succ => Ok(succ),
                err => BadRequest(new { error = err.Message })
            );
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateViPhamNoiQuyKtxDto dto)
        {
            var result = await service.CreateViPhamAsync(dto);
            return result.Match<IActionResult>(
                succ => Ok(new { id = succ }),
                err => BadRequest(new { error = err.Message })
            );
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateViPhamNoiQuyKtxDto dto)
        {
            var result = await service.UpdateViPhamAsync(dto);
            return result.Match<IActionResult>(
                succ => Ok(succ),
                err => BadRequest(new { error = err.Message })
            );
        }
    }
}