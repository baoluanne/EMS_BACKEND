using EMS.API.Controllers.Base;
using EMS.Application.Services.ChuongTrinhKhungNienCheServices.Dtos;
using EMS.Application.Services.ChuongTrinhKhungTinChiServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class ChuongTrinhKhungTinChiController(IChuongTrinhKhungTinChiService service) : BaseController<ChuongTrinhKhungTinChi>(service)
{
    private IChuongTrinhKhungTinChiService _service = service;

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.CoSoDaoTao)
            .Include(x => x.KhoaHoc)
            .Include(x => x.LoaiDaoTao)
            .Include(x => x.NganhHoc)
            .Include(x => x.BacDaoTao)
            .Include(x => x.ChuyenNganh)
            .Include(x => x.ChiTietKhungHocKy_TinChis)!
                .ThenInclude(x => x.MonHocBacDaoTao)
                .ThenInclude(x => x.MonHoc)
        );
        return result.ToResult();
    }

    [HttpGet("pagination-lophoc")]
    public virtual async Task<IActionResult> GetPaginatedWithLopHoc(
        [FromQuery] PaginationRequest request,
        [FromQuery] ChuongTrinhKhungFilter filter)
    {
        var result = _service.GetPaginatedWithLopHoc(request,
            filters: q =>
                (filter.IdCoSoDaoTao == null || q.IdCoSoDaoTao == filter.IdCoSoDaoTao)
                && (filter.IdKhoaHoc == null || q.IdKhoaHoc == filter.IdKhoaHoc)
                && (filter.IdLoaiDaoTao == null || q.IdLoaiDaoTao == filter.IdLoaiDaoTao)
                && (filter.IdNganhHoc == null || q.IdNganhHoc == filter.IdNganhHoc)
                && (filter.IdBacDaoTao == null || q.IdBacDaoTao == filter.IdBacDaoTao)
                && (filter.IdChuyenNganh == null || q.IdChuyenNganh == filter.IdChuyenNganh),
            include: q => q
                .Include(x => x.CoSoDaoTao)
                .Include(x => x.KhoaHoc)
                .Include(x => x.LoaiDaoTao)
                .Include(x => x.NganhHoc)
                .Include(x => x.BacDaoTao)
                .Include(x => x.ChuyenNganh)
                .Include(x => x.ChiTietKhungHocKy_TinChis)!
                .ThenInclude(x => x.MonHocBacDaoTao)
                .ThenInclude(x => x.MonHoc));
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] ChuongTrinhKhungFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q
                .Include(x => x.CoSoDaoTao)
                .Include(x => x.KhoaHoc)
                .Include(x => x.LoaiDaoTao)
                .Include(x => x.NganhHoc)
                .Include(x => x.BacDaoTao)
                .Include(x => x.ChuyenNganh)
                .Include(x => x.ChiTietKhungHocKy_TinChis)!
                    .ThenInclude(x => x.MonHocBacDaoTao)
                    .ThenInclude(x => x.MonHoc),
            filter: q =>
                (filter.IdCoSoDaoTao == null || q.IdCoSoDaoTao == filter.IdCoSoDaoTao)
                && (filter.IdKhoaHoc == null || q.IdKhoaHoc == filter.IdKhoaHoc)
                && (filter.IdLoaiDaoTao == null || q.IdLoaiDaoTao == filter.IdLoaiDaoTao)
                && (filter.IdNganhHoc == null || q.IdNganhHoc == filter.IdNganhHoc)
                && (filter.IdBacDaoTao == null || q.IdBacDaoTao == filter.IdBacDaoTao)
                && (filter.IdChuyenNganh == null || q.IdChuyenNganh == filter.IdChuyenNganh)
        );
        return result.ToResult();
    }

    [HttpPost("block")]
    public virtual async Task<IActionResult> UpdateIsBlock([FromBody] ChuongTrinhKhungIsBlockUpdate request)
    {
        var result = await _service.UpdateIsBlock(request);
        return result.ToResult();
    }
}