using EMS.API.Controllers.Base;
using EMS.Application.Services.LoaiQuyetDinh;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    public class LoaiQuyetDinhController: BaseController<LoaiQuyetDinh>
    {
        public LoaiQuyetDinhController(ILoaiQuyetDinhService loaiQDService) 
            : base(loaiQDService)
        {
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
                    || q.MaLoaiQD.ToLower().Contains(lowerKeyword)
                    || q.TenLoaiQD.ToLower().Contains(lowerKeyword)
            );
            return result.ToResult();
        }
    }
}