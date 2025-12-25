using EMS.API.Controllers.Base;
using EMS.Application.Services.QuyCheHocVuServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class QuyCheHocVuController : BaseController<QuyCheHocVu>
{
    public QuyCheHocVuController(IQuyCheHocVuService quyCheHocVuService) : base(quyCheHocVuService)
    {
    }

    [HttpGet("pagination")]
    public override async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request)
    {
        var result = await Service.GetPaginatedAsync(
            request
        );
        return result.ToResult();
    }
} 