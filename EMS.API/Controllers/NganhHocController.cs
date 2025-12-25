using EMS.Application.Services.NganhHocServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class NganhHocController : BaseController<NganhHoc>
{
    public NganhHocController(INganhHocService nganhHocService) : base(nganhHocService)
    {
    }
} 