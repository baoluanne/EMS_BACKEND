using EMS.API.Controllers.Base;
using EMS.Application.Services.DanhMucKhungHoSoHSSVServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class DanhMucKhungHoSoHSSVController : BaseController<DanhMucKhungHoSoHSSV>
{
    private readonly IDanhMucKhungHoSoHSSVService _danhMucKhungHoSoHSSVService;

    public DanhMucKhungHoSoHSSVController(IDanhMucKhungHoSoHSSVService danhMucKhungHoSoHSSVService) : base(danhMucKhungHoSoHSSVService)
    {
        _danhMucKhungHoSoHSSVService = danhMucKhungHoSoHSSVService;
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.BacDaoTao)
            .Include(x => x.LoaiDaoTao)
            .Include(x => x.KhoaHoc)
        );
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] DanhMucKhungHoSoHSSVFilter filter)
    {
        var lowerKeyword = filter.Keyword?.ToLower();
        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q.Include(x => x.BacDaoTao)
                .Include(x => x.LoaiDaoTao)
                .Include(x => x.HoSoHSSV)
                .Include(x => x.KhoaHoc),
            filter: q =>
                (filter.IdBacDaoTao == null || q.IdBacDaoTao == filter.IdBacDaoTao)
                && (filter.IdLoaiDaoTao == null || q.IdLoaiDaoTao == filter.IdLoaiDaoTao)
                && (filter.IdKhoaHoc == null || q.IdKhoaHoc == filter.IdKhoaHoc)
                && (filter.IdLoaiSinhVien == null || q.IdLoaiSinhVien == filter.IdLoaiSinhVien)
                && (string.IsNullOrEmpty(lowerKeyword)
                    || (q.BacDaoTao != null && q.BacDaoTao.TenBacDaoTao.ToLower().Contains(lowerKeyword))
                    || (q.LoaiDaoTao != null && q.LoaiDaoTao.TenLoaiDaoTao.ToLower().Contains(lowerKeyword))
                    || (q.KhoaHoc != null && q.KhoaHoc.TenKhoaHoc.ToLower().Contains(lowerKeyword))
                    || (q.HoSoHSSV != null && q.HoSoHSSV.TenHoSo.ToLower().Contains(lowerKeyword))
                    || (q.STT != null && q.STT.ToString().ToLower().Contains(lowerKeyword))
                    || (!string.IsNullOrEmpty(q.GhiChu) && q.GhiChu.ToLower().Contains(lowerKeyword)))
        );
        return result.ToResult();
    }
}

public class DanhMucKhungHoSoHSSVFilter
{
    public string? Keyword { get; set; }
    public Guid? IdBacDaoTao { get; set; }
    public Guid? IdLoaiDaoTao { get; set; }
    public Guid? IdKhoaHoc { get; set; }
    public Guid? IdLoaiSinhVien { get; set; }
}
