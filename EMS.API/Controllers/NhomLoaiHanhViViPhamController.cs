using EMS.Application.Services.NhomLoaiHanhViViPhamServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class NhomLoaiHanhViViPhamController : BaseController<NhomLoaiHanhViViPham>
{
    public NhomLoaiHanhViViPhamController(INhomLoaiHanhViViPhamService nhomLoaiHanhViViPhamService) : base(nhomLoaiHanhViViPhamService)
    {
    }
} 