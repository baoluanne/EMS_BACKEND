using EMS.Application.Services.LoaiKhenThuongServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class LoaiKhenThuongController : BaseController<LoaiKhenThuong>
{
    public LoaiKhenThuongController(ILoaiKhenThuongService loaiKhenThuongService) : base(loaiKhenThuongService)
    {
    }
} 