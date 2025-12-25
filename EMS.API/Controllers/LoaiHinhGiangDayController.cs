using EMS.Application.Services.LoaiHinhGiangDayServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class LoaiHinhGiangDayController : BaseController<LoaiHinhGiangDay>
{
    public LoaiHinhGiangDayController(ILoaiHinhGiangDayService loaiHinhGiangDayService) : base(loaiHinhGiangDayService)
    {
    }
} 