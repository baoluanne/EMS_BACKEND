using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucKhoanThuTuDoServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class DanhMucKhoanThuTuDoController : BaseController<DanhMucKhoanThuTuDo>
{
    private readonly IDanhMucKhoanThuTuDoService _danhMucKhoanThuTuDoService;

    public DanhMucKhoanThuTuDoController(IDanhMucKhoanThuTuDoService danhMucKhoanThuTuDoService) : base(danhMucKhoanThuTuDoService)
    {
        _danhMucKhoanThuTuDoService = danhMucKhoanThuTuDoService;
    }
    
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q.Include(x => x.LoaiKhoanThu));
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowercaseKeyword = keyword?.ToLower();

        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q
                .Include(x => x.LoaiKhoanThu),
            filter: q =>
                string.IsNullOrEmpty(lowercaseKeyword)
                || q.MaKhoanThu.ToLower().Contains(lowercaseKeyword.ToLower())
                || q.TenKhoanThu.ToLower().Contains(lowercaseKeyword.ToLower()));
        return result.ToResult();
    }
}

public class DanhMucKhoanThuTuDoFilter
{
    public string? MaKhoanThu { get; set; }
    public string? TenKhoanThu { get; set; }
    public string? LoaiKhoanThu { get; set; }
    public bool? IsVisible { get; set; }
}
