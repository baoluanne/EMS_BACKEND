using EMS.Application.Services.DanhMucPhongBanServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class DanhMucPhongBanController : BaseController<DanhMucPhongBan>
{
    public DanhMucPhongBanController(IDanhMucPhongBanService danhMucPhongBanService) : base(danhMucPhongBanService)
    {
    }
} 