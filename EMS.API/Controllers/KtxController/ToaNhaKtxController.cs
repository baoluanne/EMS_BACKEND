using EMS.API.Controllers.Base;
using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxController
{
    [Route("api/toa-nha-ktx")]
    [ApiController]

    public class ToaNhaKtxController : BaseController<ToaNhaKtx>
    {
        private readonly IToaNhaKtxService _service;

        public ToaNhaKtxController(IToaNhaKtxService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPaginated([FromQuery] PaginationRequest request)
        {
            var result = await _service.GetPaginatedAsync(request);

            return result.Match(
                succ => Ok(succ),
                err => StatusCode(500, new { message = "Lỗi lấy danh sách tòa nhà", error = err.Message })
            );
        }
    }
}