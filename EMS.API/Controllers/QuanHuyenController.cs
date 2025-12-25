using EMS.API.Controllers.Base;
using EMS.Application.Services.QuanHuyenServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers
{
    public class QuanHuyenController : BaseController<QuanHuyen>
    {
        public QuanHuyenController(IQuanHuyenService service) : base(service)
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
                include: q => q.Include(x => x.TinhThanh),
                filter: q => string.IsNullOrEmpty(lowerKeyword)
                             || q.TenQuanHuyen.ToLower().Contains(lowerKeyword)
                             || q.MaQuanHuyen.ToLower().Contains(lowerKeyword)
                             || q.TinhThanh!.TenTinhThanh.ToLower().Contains(lowerKeyword)
            );
            return result.ToResult();
        }

        [HttpGet("tinh/{idTinh}")]
        public virtual async Task<IActionResult> GetByTinhId(Guid idTinh)
        {
            var result = await Service.GetAllAsync(
                filter: q => q.IdTinhThanh == idTinh
            );
            return result.ToResult();
        }
    }
}