using EMS.API.Controllers.Base;
using EMS.Application.Services.EquipService;
using EMS.Domain.Entities.EquipmentManagement;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.EquipManagement
{
    public class ThietBiController : BaseController<TSTBThietBi>
    {
        public ThietBiController(IThietBiService service) : base(service)
        {
        }
    }
}
