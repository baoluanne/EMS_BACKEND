using EMS.Application.Services.DanhSachKhoaSuDungServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class DanhSachKhoaSuDungController : BaseController<DanhSachKhoaSuDung>
{
    public DanhSachKhoaSuDungController(IDanhSachKhoaSuDungService danhSachKhoaSuDungService) : base(danhSachKhoaSuDungService)
    {
    }
} 