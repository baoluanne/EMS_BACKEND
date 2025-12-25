using EMS.Application.Services.LoaiMonHocServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class LoaiMonHocController : BaseController<LoaiMonHoc>
{
    public LoaiMonHocController(ILoaiMonHocService loaiMonHocService) : base(loaiMonHocService)
    {
    }
} 