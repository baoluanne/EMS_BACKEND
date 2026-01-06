using EMS.API.Controllers.Base;
using EMS.Application.Services.EquipService;
using EMS.Application.Services.EquipService.Service;
using EMS.Domain.Entities.EquipmentManagement;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.EquipManagement
{
    public class ChiTietKiemKeController : BaseController<TSTBChiTietKiemKe>
    {
        public ChiTietKiemKeController(IChiTietKiemKeService service) : base(service) { }
    }
}
