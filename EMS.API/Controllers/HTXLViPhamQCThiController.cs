using EMS.Application.Services.HTXLViPhamQCThiServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class HTXLViPhamQCThiController : BaseController<HTXLViPhamQCThi>
{
    public HTXLViPhamQCThiController(IHTXLViPhamQCThiService htxlViPhamQCThiService) : base(htxlViPhamQCThiService)
    {
    }
} 