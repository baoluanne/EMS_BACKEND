using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxController
{
    public class DonGiaHanController : BaseController<KtxDonGiaHan>
    {
        private readonly IDonGiaHanService _service;
        public DonGiaHanController(IDonGiaHanService service): base(service) 
        {
            _service = service;
        }
    }
}
