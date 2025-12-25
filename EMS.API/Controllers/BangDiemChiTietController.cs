using EMS.API.Controllers.Base;
using EMS.Application.Services.BangDiemChiTietServices;
using EMS.Domain.Entities;

namespace EMS.API.Controllers;

public class BangDiemChiTietController : BaseController<BangDiemChiTiet>
{
    private readonly IBangDiemChiTietService _service;

    public BangDiemChiTietController(IBangDiemChiTietService service) : base(service)
    {
        _service = service;
    }

}