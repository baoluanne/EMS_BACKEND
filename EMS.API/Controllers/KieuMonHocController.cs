using EMS.Application.Services.KieuMonHocServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class KieuMonHocController : BaseController<KieuMonHoc>
{
    public KieuMonHocController(IKieuMonHocService kieuMonHocService) : base(kieuMonHocService)
    {
    }
} 