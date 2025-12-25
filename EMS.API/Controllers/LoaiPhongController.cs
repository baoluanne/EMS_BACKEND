using EMS.Application.Services.LoaiPhongServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class LoaiPhongController : BaseController<LoaiPhong>
{
    public LoaiPhongController(ILoaiPhongService loaiPhongService) : base(loaiPhongService)
    {
    }
} 