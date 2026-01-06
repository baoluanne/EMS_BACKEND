using EMS.API.Controllers.Base;
using EMS.Application.Services.Base;
using EMS.Application.Services.EquipService;
using EMS.Domain.Entities.EquipmentManagement;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.EquipManagement
{
    public class DotKiemKeController : BaseController<TSTBDotKiemKe>
    {
        public DotKiemKeController(IDotKiemKeService service) : base(service)
        {
        }
    }
}
