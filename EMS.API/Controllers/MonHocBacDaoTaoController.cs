using EMS.API.Controllers.Base;
using EMS.Application.Services.MonHocBacDaoTaoServices;
using EMS.Application.Services.MonHocBacDaoTaoServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using EMS.Domain.Models.Import;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class MonHocBacDaoTaoController(IMonHocBacDaoTaoService service) : BaseController<MonHocBacDaoTao>(service)
{
    private IMonHocBacDaoTaoService _service = service;

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.MonHoc)
            .ThenInclude(x => x.LoaiMonHoc)
            .Include(x => x.BacDaoTao)
        );
        return result.ToResult();
    }

    [HttpPost("batch")]
    public async Task<IActionResult> AddBatch(AddMonHocBacDaoTaoRequestDto request)
    {
        var result = await _service.AddBatchAsync(request);

        return result.ToResult();
    }

    [HttpPost("update-multiple")]
    public virtual async Task<IActionResult> UpdateMany([FromBody] List<MonHocBacDaoTao> entities)
    {
        var result = await _service.UpdateManyAsync(entities);
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] MonHocBacDaoTaoFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q
                .Include(x => x.MonHoc)
                .ThenInclude(x => x.LoaiMonHoc)
                .Include(x => x.BacDaoTao),
            filter: q =>
                (filter.IdBacDaoTao == null || q.IdBacDaoTao == filter.IdBacDaoTao)
                && (filter.IdKhoa == null || (q.MonHoc != null && q.MonHoc.IdKhoa == filter.IdKhoa))
                && (filter.IdToBoMon == null || (q.MonHoc != null && q.MonHoc.IdToBoMon == filter.IdToBoMon))
                && (filter.IdLoaiMonHoc == null || (q.MonHoc != null && q.MonHoc.IdLoaiMonHoc == filter.IdLoaiMonHoc))
                && (filter.IdTinhChatMonHoc == null ||
                    (q.MonHoc != null && q.MonHoc.IdTinhChatMonHoc == filter.IdTinhChatMonHoc))
                && (filter.IdKhoiKienThuc == null ||
                    (q.MonHoc != null && q.MonHoc.IdKhoiKienThuc == filter.IdKhoiKienThuc))
                && (filter.IdHinhThucThi == null || q.IdHinhThucThi == filter.IdHinhThucThi)
                && (filter.IdLoaiHinhGiangDay == null || q.IdLoaiHinhGiangDay == filter.IdLoaiHinhGiangDay)
                && (filter.IdMonHoc == null || q.IdMonHoc == filter.IdMonHoc)
        );
        return result.ToResult();
    }

    [HttpPost("import")]
    public override async Task<IActionResult> Import([FromBody] ImportRequest request)
    {
        if (request?.File == null || request.File.Length == 0)
            return BadRequest("File bị lỗi");
        var result = await _service.ImportAsync(request.File);
        return Ok(result);
    }
}

