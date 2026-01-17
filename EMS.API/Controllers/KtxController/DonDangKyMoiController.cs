using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Application.Services.KtxService.Service;
using EMS.Domain.Entities.KtxManagement;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxController
{
    public class DonDangKyMoiController : BaseController<KtxDonDangKyMoi>
    {
        private readonly IDonDangKyMoiService _service;
        public DonDangKyMoiController(IDonDangKyMoiService service): base(service)
        {
            _service = service;
        }
    }
}
