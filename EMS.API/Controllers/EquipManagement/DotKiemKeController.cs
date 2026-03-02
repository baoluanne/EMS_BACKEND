using EMS.API.Controllers.Base;
using EMS.Application.Services.EquipService;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.EquipManagement
{
    public class DotKiemKeController : BaseController<TSTBDotKiemKe>
    {
        public DotKiemKeController(IDotKiemKeService service) : base(service)
        {
        }

        // ... (Giữ nguyên GetAll, AddFromRoom nếu cần)

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] DotKiemKeFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                filter: q =>
                    (string.IsNullOrEmpty(filter.TenDotKiemKe) || q.TenDotKiemKe!.ToLower().Contains(filter.TenDotKiemKe.ToLower())) &&
                    (!filter.NgayBatDau.HasValue || q.NgayBatDau >= filter.NgayBatDau) &&
                    (!filter.NgayKetThuc.HasValue || q.NgayKetThuc <= filter.NgayKetThuc) &&
                    (!filter.DaHoanThanh.HasValue || q.DaHoanThanh == filter.DaHoanThanh),
                include: i => i
                    .Include(x => x.NguoiBatDau)
                    .Include(x => x.ChiTietKiemKes).ThenInclude(ct => ct.ThietBi),
                orderBy: x => x.NgayBatDau,
                isDescending: true);

            return result.ToResult();
        }

        // --- NEW API ---
        [HttpGet("active-phong-hoc")]
        public async Task<IActionResult> GetActivePhongHoc()
        {
            var result = await ((IDotKiemKeService)Service).GetActivePhongHocsAsync();
            return result.ToResult();
        }

        [HttpGet("active-phong-ktx")]
        public async Task<IActionResult> GetActivePhongKtx()
        {
            var result = await ((IDotKiemKeService)Service).GetActivePhongKtxsAsync();
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