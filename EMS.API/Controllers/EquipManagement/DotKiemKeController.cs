using EMS.API.Controllers.Base;
using EMS.Application.Services.Base;
using EMS.Application.Services.EquipService;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static EMS.API.Controllers.EquipManagement.ThietBiController;

namespace EMS.API.Controllers.EquipManagement
{
    public class DotKiemKeController : BaseController<TSTBDotKiemKe>
    {
        public DotKiemKeController(IDotKiemKeService service) : base(service)
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
    [FromQuery] DotKiemKeFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                filter: q =>
                (string.IsNullOrEmpty(filter.TenDotKiemKe) || q.TenDotKiemKe!.ToLower().Contains(filter.TenDotKiemKe.ToLower())) &&
                (filter.NgayBatDau == null || q.NgayBatDau >= filter.NgayBatDau) &&
                (filter.NgayKetThuc == null || q.NgayKetThuc <= filter.NgayKetThuc) &&
                (filter.DaHoanThanh == null || q.DaHoanThanh == filter.DaHoanThanh)
            );
            return result.ToResult();
        }

        public class DotKiemKeFilter
        {
            public string? TenDotKiemKe { get; set; }
            public DateTime? NgayBatDau { get; set; }
            public DateTime? NgayKetThuc { get; set; }
            public bool? DaHoanThanh { get; set; }
        }
    }
}
