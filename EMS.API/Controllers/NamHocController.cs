using EMS.Application.Services.NamHocServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using EMS.Domain.Extensions;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EMS.API.Controllers;

public class NamHocController : BaseController<NamHoc>
{
    public NamHocController(INamHocService namHocService) : base(namHocService)
    {
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowercaseKeyword = keyword?.ToLower();

        var result = await Service.GetPaginatedAsync(
            request,
            filter: q =>
                string.IsNullOrEmpty(lowercaseKeyword)
                || (q.NamHocValue.ToLower().Contains(lowercaseKeyword))
                || (q.NienHoc.ToLower().Contains(lowercaseKeyword))
                || (!string.IsNullOrEmpty(q.TenTiengAnh) && q.TenTiengAnh.ToLower().Contains(lowercaseKeyword))
                || (q.SoTuan != null && q.SoTuan.ToString().ToLower().Contains(lowercaseKeyword))
                || (!string.IsNullOrEmpty(q.GhiChu) && q.GhiChu.ToLower().Contains(lowercaseKeyword))
        );

        return result.ToResult();
    }
}