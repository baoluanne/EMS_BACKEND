using EMS.Application.Services.KhoiNganhServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class KhoiNganhController : BaseController<KhoiNganh>
{
    public KhoiNganhController(IKhoiNganhService khoiNganhService) : base(khoiNganhService)
    {
    }
} 