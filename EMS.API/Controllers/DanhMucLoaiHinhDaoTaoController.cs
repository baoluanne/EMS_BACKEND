using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucLoaiHinhDaoTaoServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class DanhMucLoaiHinhDaoTaoController : BaseController<DanhMucLoaiHinhDaoTao>
{
    public DanhMucLoaiHinhDaoTaoController(IDanhMucLoaiHinhDaoTaoService danhMucLoaiHinhDaoTaoService) : base(danhMucLoaiHinhDaoTaoService)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q.Include(x => x.NoiDung));
        return result.ToResult();
    }
}
