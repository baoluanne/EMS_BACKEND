using EMS.API.Controllers.Base;
using EMS.Application.Services.PhanMonLopHocServices;
using EMS.Domain.Entities;

namespace EMS.API.Controllers;

public class PhanMonLopHocController : BaseController<PhanMonLopHoc>
{
    public PhanMonLopHocController(IPhanMonLopHocService service) : base(service)
    {
    }
} 