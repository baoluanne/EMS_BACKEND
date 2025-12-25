using EMS.API.Controllers.Base;
using EMS.Application.Services.ChuanDauRaServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class ChuanDauRaController : BaseController<ChuanDauRa>
{
    public ChuanDauRaController(IChuanDauRaService chuanDauraService) : base(chuanDauraService)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.CoSo)
            .Include(x => x.KhoaHoc)
            .Include(x => x.LoaiDaoTao)
            .Include(x => x.BacDaoTao)
            .Include(x => x.LoaiChungChi)
            .Include(x => x.ChuyenNganh)
            .Include(x => x.ChungChi));
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] ChuanDauRaFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q.Include(x => x.CoSo)
                .Include(x => x.KhoaHoc)
                .Include(x => x.LoaiDaoTao)
                .Include(x => x.BacDaoTao)
                .Include(x => x.LoaiChungChi)
                .Include(x => x.ChuyenNganh)
                .Include(x => x.ChungChi),
            filter: q =>
                (filter.IdCoSo == null || q.IdCoSo == filter.IdCoSo)
                && (filter.IdKhoaHoc == null || q.IdKhoaHoc == filter.IdKhoaHoc)
                && (filter.IdBacDaoTao == null || q.IdBacDaoTao == filter.IdBacDaoTao)
                && (filter.IdLoaiDaoTao == null || q.IdLoaiDaoTao == filter.IdLoaiDaoTao)
                && (filter.IdLoaiChungChi == null || q.IdLoaiChungChi == filter.IdLoaiChungChi)
                && (filter.IdChungChi == null || q.IdChungChi == filter.IdChungChi)
                && (filter.IdChuyenNganh == null || q.IdChuyenNganh == filter.IdChuyenNganh)
        );
        return result.ToResult();
    }
}

public class ChuanDauRaFilter
{
    public Guid? IdCoSo { get; set; }
    public Guid? IdKhoaHoc { get; set; }
    public Guid? IdBacDaoTao { get; set; }
    public Guid? IdLoaiDaoTao { get; set; }
    public Guid? IdLoaiChungChi { get; set; }
    public Guid? IdChungChi { get; set; }
    public Guid? IdChuyenNganh { get; set; }
}