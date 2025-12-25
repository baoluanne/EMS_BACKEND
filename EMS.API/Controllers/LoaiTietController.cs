using EMS.Application.Services.LoaiTietServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class LoaiTietController : BaseController<LoaiTiet>
{
    public LoaiTietController(ILoaiTietService loaiTietService) : base(loaiTietService)
    {
    }
} 