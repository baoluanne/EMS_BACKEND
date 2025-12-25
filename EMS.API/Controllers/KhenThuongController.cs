using EMS.Application.Services.KhenThuongServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class KhenThuongController : BaseController<KhenThuong>
{
    public KhenThuongController(IKhenThuongService khenThuongService) : base(khenThuongService)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.LoaiKhenThuong)
        );
        return result.ToResult();
    }
    
    
    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowercaseKeyword = keyword?.ToLower();

        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q.Include(x => x.LoaiKhenThuong),
            filter: q =>
                string.IsNullOrEmpty(lowercaseKeyword)
                || q.TenKhenThuong.ToLower().Contains(lowercaseKeyword.ToLower())
                || (!string.IsNullOrEmpty(q.NoiDung) && q.NoiDung.ToLower().Contains(lowercaseKeyword.ToLower()))
                || q.MaKhenThuong.ToLower().Contains(lowercaseKeyword.ToLower()));
        return result.ToResult();
    }
}