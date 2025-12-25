using EMS.Application.Services.TrangThaiLopHPServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class TrangThaiLopHPController : BaseController<TrangThaiLopHP>
{
    public TrangThaiLopHPController(ITrangThaiLopHPService trangThaiLopHPService) : base(trangThaiLopHPService)
    {
    }
} 