using EMS.API.Controllers.Base;
using EMS.Application.Services.GiangVienServices;
using EMS.Application.Services.GiangVienServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using EMS.Domain.Models.Import;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class GiangVienController : BaseController<GiangVien>
{
    private readonly IGiangVienService _giangVienService;

    public GiangVienController(IGiangVienService giangVienService) : base(giangVienService)
    {
        _giangVienService = giangVienService;
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.LoaiGiangVien)
            .Include(x => x.HocVi)
            .Include(x => x.ToBoMon));
        return result.ToResult();
    }

    [HttpPost("import")]
    public override async Task<IActionResult> Import([FromBody] ImportRequest request)
    {
        if (request?.File == null || request.File.Length == 0)
            return BadRequest("File is invalid");
        var result = await _giangVienService.ImportAsync(request.File);
        return Ok(result);
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] GiangVienFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q.Include(x => x.LoaiGiangVien).Include(x => x.ToBoMon).Include(x => x.HocVi),
            filter: q =>
                (string.IsNullOrEmpty(filter.MaGiangVien)
                 || q.MaGiangVien.Contains(filter.MaGiangVien))
                && (string.IsNullOrEmpty(filter.HoVaTen)
                    || EF.Functions.Like(
                        ((q.HoDem ?? "") + " " + (q.Ten ?? "")).Trim(),
                        $"%{filter.HoVaTen}%"))
                &&
                (!filter.NgayChamDutHopDong.HasValue
                 || (q.NgayChamDutHopDong.HasValue
                     && q.NgayChamDutHopDong.Value.Date == filter.NgayChamDutHopDong.Value.Date))
                && (filter.IdKhoa == null
                    || q.IdKhoa == filter.IdKhoa)
                && (filter.IdLoaiGiangVien == null
                    || q.IdLoaiGiangVien == filter.IdLoaiGiangVien)
        );

        return result.ToResult();
    }
}