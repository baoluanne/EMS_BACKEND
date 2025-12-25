using EMS.API.Controllers.Base;
using EMS.Application.Services.QuyChuanDauRaServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class QuyChuanDauRaController : BaseController<QuyChuanDauRa>
{
    public QuyChuanDauRaController(IQuyChuanDauRaService service) : base(service)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.CoSoDaoTao)
            .Include(x => x.KhoaHoc)
            .Include(x => x.LoaiDaoTao)
            .Include(x => x.BacDaoTao)
            .Include(x => x.LoaiChungChi)
            .Include(x => x.ChungChi)
            .Include(x => x.ChuyenNganh));
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] QuyChuanDauRaFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q.Include(x => x.CoSoDaoTao)
                .Include(x => x.KhoaHoc)
                .Include(x => x.LoaiDaoTao)
                .Include(x => x.BacDaoTao)
                .Include(x => x.LoaiChungChi)
                .Include(x => x.ChungChi)
                .Include(x => x.ChuyenNganh),
            filter: q =>
                (filter.IdCoSo == null || q.IdCoSoDaoTao == filter.IdCoSo)
                && (filter.IdKhoaHoc == null || q.IdKhoaHoc == filter.IdKhoaHoc)
                && (filter.IdBacDaoTao == null || q.IdBacDaoTao == filter.IdBacDaoTao)
                && (filter.IdLoaiDaoTao == null || q.IdLoaiDaoTao == filter.IdLoaiDaoTao)
                && (filter.IdLoaiChungChi == null || q.IdLoaiChungChi == filter.IdLoaiChungChi)
                && (filter.IdChungChi == null || q.IdChungChi == filter.IdChungChi)
                && (filter.IdChuyenNganh == null || q.IdChuyenNganh == filter.IdChuyenNganh)
                && (filter.IsChuanDauRaBoSung ? q.IsChuanDauRaBoSung : !q.IsChuanDauRaBoSung)
        );
        return result.ToResult();
    }
}

public class QuyChuanDauRaFilter
{
    public Guid? IdCoSo { get; set; }
    public Guid? IdKhoaHoc { get; set; }
    public Guid? IdBacDaoTao { get; set; }
    public Guid? IdLoaiDaoTao { get; set; }
    public Guid? IdLoaiChungChi { get; set; }
    public Guid? IdChungChi { get; set; }
    public Guid? IdChuyenNganh { get; set; }
    public bool IsChuanDauRaBoSung { get; set; }
}