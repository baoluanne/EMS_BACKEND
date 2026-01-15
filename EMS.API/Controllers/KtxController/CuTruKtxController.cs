using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/cu-tru-ktx")]
[ApiController]
public class CuTruKtxController : BaseController<KtxCutru>
{
    private readonly ICuTruKtxService _service;
    public CuTruKtxController(ICuTruKtxService service) : base(service)
    {
        _service = service;
    }

}