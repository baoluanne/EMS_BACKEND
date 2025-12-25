using EMS.Application.Services.QuyChe_TinChi_Services;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class QuyChe_TinChi_Controller : BaseController<QuyChe_TinChi>
{
    private readonly IQuyChe_TinChi_Service _quyCheTinChiService;

    public QuyChe_TinChi_Controller(IQuyChe_TinChi_Service quyCheTinChiService) : base(quyCheTinChiService)
    {
        _quyCheTinChiService = quyCheTinChiService;
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
        var result = await _quyCheTinChiService.GetByQuyCheHocVuIdAsync(quyCheHocVuId);
        return Ok(result);
    }
}