using EMS.API.Controllers.Base;
using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxManagement;

[Route("api/[Controller]")]
[ApiController]
public class ChiSoDienNuocController : BaseController<ChiSoDienNuoc>
{
    private readonly IChiSoDienNuocService _service;

    public ChiSoDienNuocController(IChiSoDienNuocService service) : base(service)
    {
        _service = service;
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> GetPagination([FromQuery] PaginationRequest request, [FromQuery] ChiSoDienNuocFilter filter)
    {
        var result = await _service.GetPaginatedAsync(request, filter);
        return result.ToResult();
    }
}