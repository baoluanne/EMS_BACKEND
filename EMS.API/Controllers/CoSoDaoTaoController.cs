using EMS.Application.Services.CoSoDaoTaoServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class CoSoDaoTaoController : BaseController<CoSoDaoTao>
{
    public CoSoDaoTaoController(ICoSoDaoTaoService coSoDaoTaoService) : base(coSoDaoTaoService)
    {
    }
} 