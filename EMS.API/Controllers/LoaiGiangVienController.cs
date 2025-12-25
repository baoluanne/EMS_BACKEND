using EMS.Application.Services.LoaiGiangVienServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class LoaiGiangVienController : BaseController<LoaiGiangVien>
{
    public LoaiGiangVienController(ILoaiGiangVienService loaiGiangVienService) : base(loaiGiangVienService)
    {
    }
} 