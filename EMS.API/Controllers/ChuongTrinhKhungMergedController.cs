using EMS.API.Controllers.Base;
using EMS.Application.Services.ChuongTrinhKhungMergedServices;
using EMS.Domain.Dtos;
using EMS.Domain.Entities.Views;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class ChuongTrinhKhungMergedController(IChuongTrinhKhungMergedService chuongTrinhKhungMergedService) : BaseController<ChuongTrinhKhungMerged>(chuongTrinhKhungMergedService)
{
    private readonly IChuongTrinhKhungMergedService _chuongTrinhKhungMergedService = chuongTrinhKhungMergedService;

    [HttpGet("pagination")]
    public virtual Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] ChuongTrinhKhungFilter filter)
    {
        var result = _chuongTrinhKhungMergedService.GetPaginatedMerged(request, filter);
        return Task.FromResult(result.ToResult());
    }
}
