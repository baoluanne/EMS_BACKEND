using EMS.API.Controllers.Base;
using EMS.Application.Services.Base;
using EMS.Application.Services.TinhThanhServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    public class TinhThanhController : BaseController<TinhThanh>
    {
        public TinhThanhController(ITinhThanhService service) : base(service)
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
                             || q.TenTinhThanh.ToLower().Contains(lowerKeyword)
                             || q.MaTinhThanh.ToLower().Contains(lowerKeyword)
                             
            );
            return result.ToResult();
        } 
    }
}