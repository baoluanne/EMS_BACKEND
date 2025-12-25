using EMS.Application.Services.MucDoViPhamServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class MucDoViPhamController : BaseController<MucDoViPham>
{
    public MucDoViPhamController(IMucDoViPhamService mucDoViPhamService) : base(mucDoViPhamService)
    {
    }
} 