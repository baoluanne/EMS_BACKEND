using EMS.API.Controllers.Base;
using EMS.Application.Services.EquipService;
using EMS.Domain.Entities.EquipmentManagement;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.EquipManagement
{
    public class PhieuBaoTriController : BaseController<TSTBPhieuBaoTri>
    {
        public PhieuBaoTriController(IPhieuBaoTriService service) : base(service)
        {
        }
    }
}
