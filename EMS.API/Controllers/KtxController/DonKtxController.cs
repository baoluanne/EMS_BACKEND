using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxController
{
    [Route("api/don-ktx")]
    [ApiController]
    public class DonKtxController : BaseController<KtxDon>
    {
        private readonly IDonKtxService _service;

        public DonKtxController(IDonKtxService service) : base(service)
        {
            _service = service;
        }
    }
}