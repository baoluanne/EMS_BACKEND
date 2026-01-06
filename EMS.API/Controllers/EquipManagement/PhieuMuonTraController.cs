using EMS.API.Controllers.Base;
using EMS.Application.Services.EquipService;
using EMS.Domain.Entities.EquipmentManagement;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.EquipManagement
{
    public class PhieuMuonTraController : BaseController<TSTBPhieuMuonTra>
    {
        public PhieuMuonTraController(IPhieuMuonTraService service) : base(service)
        {
        }
    }
}
