using EMS.Application.Services.KieuLamTronServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class KieuLamTronController : BaseController<KieuLamTron>
{
    public KieuLamTronController(IKieuLamTronService kieuLamTronService) : base(kieuLamTronService)
    {
    }
} 