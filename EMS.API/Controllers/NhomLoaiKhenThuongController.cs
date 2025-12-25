using EMS.Application.Services.NhomLoaiKhenThuongServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class NhomLoaiKhenThuongController : BaseController<NhomLoaiKhenThuong>
{
    public NhomLoaiKhenThuongController(INhomLoaiKhenThuongService nhomLoaiKhenThuongService) : base(nhomLoaiKhenThuongService)
    {
    }
} 