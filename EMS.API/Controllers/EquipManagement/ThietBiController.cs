using EMS.API.Controllers.Base;
using EMS.Application.Services.EquipService;
using EMS.Application.Services.EquipService.Dtos;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Enums.EquipmentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.EquipManagement
{
    public class ThietBiController : BaseController<TSTBThietBi>
    {
        private readonly IThietBiService _thietBiService;
        public ThietBiController(IThietBiService service) : base(service) { _thietBiService = service; }

        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination([FromQuery] PaginationRequest request, [FromQuery] ThietBiFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                filter: q =>
                (string.IsNullOrEmpty(filter.MaThietBi) || q.MaThietBi!.ToLower().Contains(filter.MaThietBi.ToLower())) &&
                (string.IsNullOrEmpty(filter.TenThietBi) || q.TenThietBi!.ToLower().Contains(filter.TenThietBi.ToLower())) &&
                (filter.TrangThai == null || q.TrangThai == filter.TrangThai) &&
                (string.IsNullOrEmpty(filter.PhongHocId) || q.PhongHocId.ToString() == filter.PhongHocId) &&
                (string.IsNullOrEmpty(filter.PhongKtxId) || q.PhongKtxId.ToString() == filter.PhongKtxId),
                include: query => query.Include(x => x.LoaiThietBi).Include(x => x.NhaCungCap).Include(x => x.PhongHoc).Include(x => x.PhongKtx)
            );
            return result.ToResult();
        }

        [HttpPost("nhap-hang-loat")]
        public async Task<IActionResult> NhapHangLoat([FromBody] NhapHangLoatDto dto)
        {
            var result = await _thietBiService.NhapHangLoatAsync(dto);
            return result.Match(succ => Ok(succ), err => StatusCode(500, err.Message));
        }

        [HttpPost("phan-vao-phong/{targetId:guid}")]
        public async Task<IActionResult> PhanVaoPhong(Guid targetId, [FromBody] List<Guid> thietBiIds, [FromQuery] bool isKtx = false)
        {
            var result = await _thietBiService.PhanVaoPhongAsync(targetId, thietBiIds, isKtx);
            return result.Match(succ => Ok(succ), err => StatusCode(500, err.Message));
        }

        public class ThietBiFilter
        {
            public string? MaThietBi { get; set; }
            public string? TenThietBi { get; set; }
            public TrangThaiThietBiEnum? TrangThai { get; set; }
            public string? PhongHocId { get; set; }
            public string? PhongKtxId { get; set; }
        }
    }
}