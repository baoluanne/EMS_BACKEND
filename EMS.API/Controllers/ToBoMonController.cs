using EMS.Application.Services.ToBoMonServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class ToBoMonController : BaseController<ToBoMon>
{
    public ToBoMonController(IToBoMonService toBoMonService) : base(toBoMonService)
    {
    }
} 