using EMS.Application.Services.ChuyenNganhServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMS.Domain.Extensions;

namespace EMS.API.Controllers;

public class ChuyenNganhController : BaseController<ChuyenNganh>
{
    public ChuyenNganhController(IChuyenNganhService chuyenNganhService) : base(chuyenNganhService)
    {
    }
    
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q.Include(x => x.NganhHoc));
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] Guid? idNganhHoc,
        [FromQuery] string? keyword)
    {
        var lowercaseKeyword = keyword?.ToLower();

        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q.Include(x => x.NganhHoc),
            filter: q =>
                (idNganhHoc == null || q.IdNganhHoc == idNganhHoc) &&
                (string.IsNullOrEmpty(lowercaseKeyword)
                    || q.MaChuyenNganh.ToLower().Contains(lowercaseKeyword)
                    || q.TenChuyenNganh.ToLower().Contains(lowercaseKeyword)
                    || (!string.IsNullOrEmpty(q.GhiChu) && q.GhiChu.ToLower().Contains(lowercaseKeyword))
                    || (q.NganhHoc != null && q.NganhHoc.TenNganhHoc.ToLower().Contains(lowercaseKeyword))
                    || (!string.IsNullOrEmpty(q.TenVietTat) && q.TenVietTat.ToLower().Contains(lowercaseKeyword))
                    || (!string.IsNullOrEmpty(q.TenTiengAnh) && q.TenTiengAnh.ToLower().Contains(lowercaseKeyword))
                    || (q.STT != null && q.STT.ToString().ToLower().Contains(lowercaseKeyword))
                )
        );
        return result.ToResult();
    }
} 