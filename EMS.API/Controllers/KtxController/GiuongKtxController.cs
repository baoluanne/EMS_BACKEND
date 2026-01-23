using DocumentFormat.OpenXml.InkML;
using EMS.API.Controllers.Base;
using EMS.API.Controllers.KtxManagement;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Enums;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.KtxController
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiuongKtxController(IGiuongKtxService service) : BaseController<KtxGiuong>(service)
    {
        private readonly IGiuongKtxService _service = service;

        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] GiuongFilter filter)
        {
            Guid? phongGuid = null;
            if (!string.IsNullOrEmpty(filter.PhongId) && Guid.TryParse(filter.PhongId, out var parsedGuid))
            {
                phongGuid = parsedGuid;
            }

            var result = await _service.GetPaginatedAsync(
                request,
                filter: q =>
                    (string.IsNullOrEmpty(filter.MaGiuong) || q.MaGiuong!.ToLower().Contains(filter.MaGiuong.ToLower()))
                    && (phongGuid == null || q.PhongKtxId == phongGuid)
                    && (filter.TrangThai == null || q.TrangThai == filter.TrangThai),
                include: q => q.Include(x => x.Phong)
            );

            return result.ToResult();
        }
    }
}
public class GiuongFilter
{
    public string? MaGiuong { get; set; }
    public string? SinhVienId { get; set; }
    public string? PhongId { get; set; }
    public KtxGiuongTrangThai? TrangThai { get; set; }
}
