using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucDanTocServices;
using EMS.Domain.Entities.Category;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.Category
{
    public class DanhMucDanTocController : BaseController<DanhMucDanToc>
    {
        public DanhMucDanTocController(IDanhMucDanTocService service) : base(service)
        {
        }

        public override async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync();
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
                filter: q => string.IsNullOrEmpty(lowercaseKeyword)
                             || (q.MaDanToc.ToLower().Contains(lowercaseKeyword))
                             || (q.TenDanToc.ToLower().Contains(lowercaseKeyword)));

            return result.ToResult();
        }
    }
}