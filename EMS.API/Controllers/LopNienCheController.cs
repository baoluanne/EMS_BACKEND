using EMS.Application.Services.LopNienCheServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class LopNienCheController : BaseController<LopNienChe>
{
    public LopNienCheController(ILopNienCheService lopNienCheService) : base(lopNienCheService)
    {
    }
} 