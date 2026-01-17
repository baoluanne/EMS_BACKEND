using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxController
{
    public class DonChuyenPhongController : BaseController<KtxDonChuyenPhong>
    {
        private readonly IDonChuyenPhongService _service;
        public DonChuyenPhongController
            (IDonChuyenPhongService service) : base(service)
        {
            _service = service;
        }
    }
}
