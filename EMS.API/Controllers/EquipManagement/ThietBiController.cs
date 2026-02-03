using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EMS.API.Controllers.Base;
using EMS.Application.Services.EquipService;
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

        public ThietBiController(IThietBiService service) : base(service)
        {
            _thietBiService = service;
        }

        [HttpPost("multiple")]
        public override async Task<IActionResult> CreateMany([FromBody] TSTBThietBi[] entities)
        {
            var result = await _thietBiService.CreateManyAsync(entities);
            return result.ToResult();
        }

        [HttpGet("pagination")]
        public virtual async Task<IActionResult> GetPagination([FromQuery] PaginationRequest request, [FromQuery] ThietBiFilter filter)
        {
            var result = await Service.GetPaginatedAsync(
                request,
                filter: q =>
                (string.IsNullOrEmpty(filter.MaThietBi) || q.MaThietBi!.ToLower().Contains(filter.MaThietBi.ToLower())) &&
                (string.IsNullOrEmpty(filter.TenThietBi) || q.TenThietBi!.ToLower().Contains(filter.TenThietBi.ToLower())) &&
                (filter.TrangThai == null || q.TrangThai == filter.TrangThai) &&
                (filter.PhongHocId == null || q.PhongHocId == filter.PhongHocId) &&
                (filter.PhongKtxId == null || q.PhongKtxId == filter.PhongKtxId) &&
                (filter.LoaiThietBiId == null || q.LoaiThietBiId == filter.LoaiThietBiId),
                include: query => query
                    .Include(x => x.LoaiThietBi)
                    .Include(x => x.NhaCungCap)
                    .Include(x => x.PhongHoc)
                    .Include(x => x.PhongKtx)
            );
            return result.ToResult();
        }

        [HttpPost("phan-vao-phong/{targetId:guid}")]
        public async Task<IActionResult> PhanVaoPhong(Guid targetId, [FromBody] List<Guid> thietBiIds, [FromQuery] bool isKtx = false)
        {
            var result = await _thietBiService.PhanVaoPhongAsync(targetId, thietBiIds, isKtx);
            return result.Match(
                succ => Ok(succ),
                err => StatusCode(500, err.Message)
            );
        }

        public class ThietBiFilter
        {
            public string? MaThietBi { get; set; }
            public string? TenThietBi { get; set; }
            public TrangThaiThietBiEnum? TrangThai { get; set; }
            public Guid? PhongHocId { get; set; }
            public Guid? PhongKtxId { get; set; }
            public Guid? LoaiThietBiId { get; set; }
        }
    }
}