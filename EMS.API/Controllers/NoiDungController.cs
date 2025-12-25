using EMS.API.Controllers.Base;
using EMS.Application.Services.NoiDungServices;
using EMS.Domain.Entities;

namespace EMS.API.Controllers;

public class NoiDungController : BaseController<NoiDung>
{
    public NoiDungController(INoiDungService noiDungService) : base(noiDungService)
    {
    }
}
