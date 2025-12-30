using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxManagement;

[ApiController]
[Route("api/[controller]")]
public class PhongKtxController(IPhongKtxService service) : BaseController<PhongKtx>(service)
{
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync();
        return result.ToResult();
    }
    [HttpGet("pagination")]
    public async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? maPhong,
        [FromQuery] string? toaNhaId,
        [FromQuery] string? trangThai)
    {
        var result = await service.GetPaginatedAsync(request, maPhong, toaNhaId, trangThai);

        return result.Match<IActionResult>(
            Succ: Ok,
            Fail: err => BadRequest(new { error = err.Message })
        );
    }

}