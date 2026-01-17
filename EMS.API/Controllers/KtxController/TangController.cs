using EMS.API.Controllers.Base;
using EMS.Application.Services.Base;
using EMS.Application.Services.KtxService;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.KtxController
{
    public class TangController : BaseController<KtxTang>
    {
        public TangController(ITangService service) : base(service)
        {
        }
        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] Guid? ToaNhaId)
        {
            var result = await Service.GetPaginatedAsync(
            request,
            filter: q => ToaNhaId == null || q.ToaNhaId == ToaNhaId
            );
            return result.ToResult();
        }
    }
}
