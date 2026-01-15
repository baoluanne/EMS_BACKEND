using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxManagement;

[Route("api/yeu-cau-sua-chua")]
[ApiController]
public class YeuCauSuaChuaController : BaseController<KtxYeuCauSuaChua>
{
    private readonly IYeuCauSuaChuaService _service;

    public YeuCauSuaChuaController(IYeuCauSuaChuaService service) : base(service)
    {
        _service = service;
    }

}