using EMS.Application.Services.HinhThucDaoTaoServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class HinhThucDaoTaoController : BaseController<HinhThucDaoTao>
{
    public HinhThucDaoTaoController(IHinhThucDaoTaoService hinhThucDaoTaoService) : base(hinhThucDaoTaoService)
    {
    }
}