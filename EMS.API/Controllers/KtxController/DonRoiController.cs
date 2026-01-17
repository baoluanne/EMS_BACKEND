using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxController
{
    public class DonRoiController : BaseController<KtxDonRoiKtx>
    {
        private readonly IDonRoiService _service;
        public DonRoiController(IDonRoiService service): base(service)
        {
            _service = service;
        }
    }
}
