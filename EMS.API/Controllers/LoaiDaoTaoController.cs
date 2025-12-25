using System.Linq.Expressions;
using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucLoaiHinhDaoTaoServices;
using EMS.Application.Services.LoaiDaoTaoServices;
using EMS.Application.Services.LoaiDaoTaoServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class LoaiDaoTaoController : BaseController<LoaiDaoTao>
{
    public LoaiDaoTaoController(ILoaiDaoTaoService loaiDaoTaoService) : base(loaiDaoTaoService)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync();
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowerKeyword = keyword?.ToLower();
        var result = await Service.GetPaginatedAsync(
            request,
            filter: q => string.IsNullOrEmpty(lowerKeyword)
                         || (q.MaLoaiDaoTao.ToLower().Contains(lowerKeyword))
                         || (q.TenLoaiDaoTao.ToLower().Contains(lowerKeyword))
                         || (!string.IsNullOrEmpty(q.TenTiengAnh) && q.TenTiengAnh.ToLower().Contains(lowerKeyword))
                         || (!string.IsNullOrEmpty(q.GhiChu) && q.GhiChu.ToLower().Contains(lowerKeyword))
                         || (q.SoThuTu != null && q.SoThuTu.ToString()!.Contains(lowerKeyword))
                         || (!string.IsNullOrEmpty(q.NoiDung) && q.NoiDung.ToLower().Contains(lowerKeyword))
        );

        return result.ToResult();
    }
}