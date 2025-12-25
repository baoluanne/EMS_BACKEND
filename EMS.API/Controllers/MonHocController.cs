using EMS.API.Controllers.Base;
using EMS.Application.Services.MonHocServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using EMS.Domain.Models.Import;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class MonHocController : BaseController<MonHoc>
{
    private readonly IMonHocService _monHocService;

    public MonHocController(IMonHocService monHocService) : base(monHocService)
    {
        _monHocService = monHocService;
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.LoaiTiet)
            .Include(x => x.KhoiKienThuc)
            .Include(x => x.LoaiMonHoc)
            .Include(x => x.TinhChatMonHoc)
            .Include(x => x.Khoa)
            .Include(x => x.ToBoMon).ThenInclude(x => x.Khoa)
        );
        return result.ToResult();
    }

    [HttpPost("import")]
    public override async Task<IActionResult> Import([FromBody] ImportRequest request)
    {
        if (request?.File == null || request.File.Length == 0)
            return BadRequest("File is invalid");
        var result = await _monHocService.ImportAsync(request.File);
        return Ok(result);
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] MonHocFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q.Include(x => x.LoaiTiet)
                .Include(x => x.KhoiKienThuc)
                .Include(x => x.LoaiMonHoc)
                .Include(x => x.TinhChatMonHoc)
                .Include(x  => x.Khoa)
                .Include(x => x.ToBoMon).ThenInclude(x => x.Khoa),
            filter: q =>
                (filter.IdKhoa == null || q.IdKhoa == filter.IdKhoa)
                || (filter.IdToBoMon == null || q.IdToBoMon == filter.IdToBoMon)
                || (filter.IdLoaiMonHoc == null || q.IdLoaiMonHoc == filter.IdLoaiMonHoc)
                || (filter.IdTinhChatMonHoc == null || q.IdTinhChatMonHoc == filter.IdTinhChatMonHoc)
                || (filter.IdKhoiKienThuc == null || q.IdKhoiKienThuc == filter.IdKhoiKienThuc)
                || (string.IsNullOrEmpty(filter.TenMonHoc) ||
                    q.TenMonHoc.ToLower().Contains(filter.TenMonHoc.ToLower()))
                || (string.IsNullOrEmpty(filter.MaTuQuan) ||
                    (!string.IsNullOrEmpty(q.MaTuQuan) &&
                     q.MaTuQuan.ToLower().Contains(filter.MaTuQuan.ToLower())))
                || (filter.LocTheoToBoMon == null
                    || (filter.LocTheoToBoMon == 1 && q.IdToBoMon != null)
                    || (filter.LocTheoToBoMon == 2 && q.IdToBoMon == null))
                || (filter.SoTinChi != null || q.SoTinChi == filter.SoTinChi)
        );
        return result.ToResult();
    }
}

public class MonHocFilter
{
    public Guid? IdKhoa { get; set; }
    public Guid? IdToBoMon { get; set; }
    public Guid? IdLoaiMonHoc { get; set; }
    public Guid? IdTinhChatMonHoc { get; set; }
    public Guid? IdKhoiKienThuc { get; set; }
    public string? TenMonHoc { get; set; }
    public string? MaTuQuan { get; set; }
    public int? LocTheoToBoMon { get; set; }
    public int? SoTinChi { get; set; }
}