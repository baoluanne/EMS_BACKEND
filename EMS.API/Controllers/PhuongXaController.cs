using EMS.API.Controllers.Base;
using EMS.Application.Services.PhuongXaServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers
{
    public class PhuongXaController : BaseController<PhuongXa>
    {
        public PhuongXaController(IPhuongXaService service) : base(service)       
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
                include: q => q.Include(x => x.QuanHuyen),
                filter: q => string.IsNullOrEmpty(lowerKeyword) 
                             || q.TenPhuongXa.ToLower().Contains(lowerKeyword)
                             || q.MaPhuongXa.ToLower().Contains(lowerKeyword)
                             || q.QuanHuyen!.TenQuanHuyen.ToLower().Contains(lowerKeyword)
                             
            );
            return result.ToResult();
        } 
        
        [HttpGet("huyen/{idHuyen}")]
        public virtual async Task<IActionResult> GetByHuyenId(Guid idHuyen)
        {
            var result = await Service.GetAllAsync(
                filter: q => q.IdQuanHuyen == idHuyen
            );
            return result.ToResult();
        }
    }
}