using System;
using System.Threading.Tasks;
using EMS.API.Controllers.Base;
using EMS.Application.Services.EquipService;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers.EquipManagement
{
    public class PhieuThanhLyController : BaseController<TSTBPhieuThanhLy>
    {
        public PhieuThanhLyController(IPhieuThanhLyService service) : base(service)
        {
        }

        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination(
            [FromQuery] PaginationRequest request,
            [FromQuery] PhieuThanhLyFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                filter: q =>
                    (string.IsNullOrEmpty(filter.SoQuyetDinh) || q.SoQuyetDinh.ToLower().Contains(filter.SoQuyetDinh.ToLower())) &&
                    (!filter.TuNgay.HasValue || q.NgayThanhLy >= filter.TuNgay) &&
                    (!filter.DenNgay.HasValue || q.NgayThanhLy <= filter.DenNgay),
                include: i => i
                    .Include(x => x.NguoiLapPhieu)
                    .Include(x => x.ChiTietThanhLys)
                        .ThenInclude(ct => ct.ThietBi),
                orderBy: x => x.NgayThanhLy,
                isDescending: true);

            return result.ToResult();
        }

        public class PhieuThanhLyFilter
        {
            public string? SoQuyetDinh { get; set; }
            public DateTime? TuNgay { get; set; }
            public DateTime? DenNgay { get; set; }
        }
    }
}