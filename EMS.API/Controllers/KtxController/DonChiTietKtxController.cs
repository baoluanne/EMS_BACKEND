
using EMS.API.Controllers.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;

namespace EMS.API.Controllers.KtxController
{
    public class DonChiTietKtxController : BaseController<KtxDonChiTiet>
    {
        private readonly IDonChiTietKtxService _service;
        public DonChiTietKtxController(IDonChiTietKtxService service) : base(service) => _service = service;
    }
}
