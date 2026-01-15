using Microsoft.AspNetCore.Mvc;
using EMS.API.Controllers.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Application.Services.KtxService;

namespace EMS.API.Controllers.KtxManagement
{
    [Route("api/vi-pham-noiquy-ktx")]
    [ApiController]
    public class ViPhamNoiQuyKTXController(IViPhamNoiQuyKTXService service) : BaseController<KtxViPhamNoiQuy>(service)
    {
    }
}