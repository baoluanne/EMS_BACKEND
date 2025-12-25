using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Application.Services.NamHoc_HocKyServices;
using EMS.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class NamHoc_HocKyController : BaseController<NamHoc_HocKy>
{
    public NamHoc_HocKyController(INamHoc_HocKyService service) : base(service)
    {
    }
}