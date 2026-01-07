using EMS.API.Controllers.Base;
using EMS.Application.Services.EquipService;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.EquipManagement
{
    public class LoaiThietBiController : BaseController<TSTBLoaiThietBi>
    {
        public LoaiThietBiController(ILoaiThietBiService service) : base(service)
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
            [FromQuery] LoaiThietBiFilter filter)
        {

            var result = await Service.GetPaginatedAsync(
                request,
                filter: q =>
                (string.IsNullOrEmpty(filter.LoaiThietBi) || q.TenLoai!.ToLower().Contains(filter.LoaiThietBi.ToLower())) &&
                (string.IsNullOrEmpty(filter.MaLoai) || q.MaLoai!.ToLower().Contains(filter.MaLoai.ToLower()))
                && (string.IsNullOrEmpty(filter.MoTa) || q.MoTa!.ToLower().Contains(filter.MoTa.ToLower()))
            );

            return result.ToResult();
        }
        public class LoaiThietBiFilter
        {
            public string? LoaiThietBi { get; set; }
            public string? MaLoai { get; set; }
            public string? MoTa { get; set; }
        }
    }
}
