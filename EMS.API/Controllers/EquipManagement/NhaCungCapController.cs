using EMS.API.Controllers.Base;
using EMS.Application.Services.EquipService;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.EquipManagement
{
    public class NhaCungCapController : BaseController<TSTBNhaCungCap>
    {
        public NhaCungCapController(INhaCungCapService service) : base(service)
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
            [FromQuery] NhaCungCapFilter filter)
        {

            var result = await Service.GetPaginatedAsync(
                request,
                filter: q =>
                (string.IsNullOrEmpty(filter.TenNhaCungCap) || q.TenNhaCungCap!.ToLower().Contains(filter.TenNhaCungCap.ToLower())) &&
                (string.IsNullOrEmpty(filter.DiaChi) || q.DiaChi!.ToLower().Contains(filter.DiaChi.ToLower())) &&
                (string.IsNullOrEmpty(filter.GhiChu) || q.GhiChu!.ToLower().Contains(filter.GhiChu.ToLower())) &&
                (string.IsNullOrEmpty(filter.Email) || q.Email!.ToLower().Contains(filter.Email.ToLower())) &&
                (!filter.DienThoai.HasValue || q.DienThoai!.ToLower().Contains(filter.DienThoai.ToString().ToLower()))
            );

            return result.ToResult();
        }
        public class NhaCungCapFilter
        {
            public string? TenNhaCungCap { get; set; }
            public int? DienThoai { get; set; }
            public string? Email { get; set; }
            public string? DiaChi { get; set; }
            public string? GhiChu { get; set; }
        }
    }
}
