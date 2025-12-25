using EMS.Application.Services.HocViServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class HocViController : BaseController<HocVi>
{
    public HocViController(IHocViService hocViService) : base(hocViService)
    {
    }
} 