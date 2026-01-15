using DocumentFormat.OpenXml.InkML;
using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxController
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiuongKtxController : BaseController<KtxGiuong>
    {
        private readonly IGiuongKtxService _service;

        public GiuongKtxController(IGiuongKtxService service) : base(service)
        {
            _service = service;
        }

    }
}