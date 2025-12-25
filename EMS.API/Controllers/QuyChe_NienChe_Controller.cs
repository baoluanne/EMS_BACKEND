using EMS.Application.Services.QuyChe_NienChe_Services;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class QuyChe_NienChe_Controller : BaseController<QuyChe_NienChe>
{
    private readonly IQuyChe_NienChe_Service _quyCheNienCheService;
    public QuyChe_NienChe_Controller(IQuyChe_NienChe_Service quyCheNienCheService) : base(quyCheNienCheService)
    {
        _quyCheNienCheService = quyCheNienCheService;
    }
    
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.QuyCheHocVu)
        );
        return result.ToResult();
    }

    [HttpGet("by-quychehocvu/{quyCheHocVuId:guid}")]
    public async Task<IActionResult> GetByQuyCheHocVuId(Guid quyCheHocVuId)
    {
        var result = await _quyCheNienCheService.GetByQuyCheHocVuIdAsync(quyCheHocVuId);
        return Ok(result);
    }
} 