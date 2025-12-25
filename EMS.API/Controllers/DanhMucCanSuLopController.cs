using Microsoft.EntityFrameworkCore;
using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucCanSuLopServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class DanhMucCanSuLopController : BaseController<DanhMucCanSuLop>
{
    private readonly IDanhMucCanSuLopService _danhMucCanSuLopService;

    public DanhMucCanSuLopController(IDanhMucCanSuLopService danhMucCanSuLopService) : base(danhMucCanSuLopService)
    {
        _danhMucCanSuLopService = danhMucCanSuLopService;
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q.Include(x => x.LoaiChucVu));
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
            include: q => q.Include(x => x.LoaiChucVu),
            filter: q => string.IsNullOrEmpty(lowerKeyword)
            || (q.MaChucVu.ToLower().Contains(lowerKeyword))
            || (q.TenChucVu.ToLower().Contains(lowerKeyword))
            || (q.LoaiChucVu != null && q.LoaiChucVu.TenLoaiChucVu.ToLower().Contains(lowerKeyword))
            || (!string.IsNullOrEmpty(q.TenTiengAnh) && q.TenTiengAnh.ToLower().Contains(lowerKeyword))
            || (q.DiemCong != null && q.DiemCong.ToString().ToLower().Contains(lowerKeyword))
            || (q.STT != null && q.STT.ToString().ToLower().Contains(lowerKeyword))
            || (!string.IsNullOrEmpty(q.GhiChu) && q.GhiChu.ToLower().Contains(lowerKeyword))
        );
        return result.ToResult();
    }
}
