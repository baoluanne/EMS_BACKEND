using EMS.Application.Services.TrangThaiXetQuyUocServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class TrangThaiXetQuyUocController : BaseController<TrangThaiXetQuyUoc>
{
    public TrangThaiXetQuyUocController(ITrangThaiXetQuyUocService trangThaiXetQuyUocService) : base(trangThaiXetQuyUocService)
    {
    }
} 