using EMS.API.Controllers.Base;
using EMS.Application.Services.ChiTietKhungHocKy_TinChiServices;
using EMS.Application.Services.ChiTietKhungHocKy_TinChiServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class ChiTietKhungHocKy_TinChiController : BaseController<ChiTietKhungHocKy_TinChi>
{
    private IChiTietKhungHocKy_TinChiService _service;

    public ChiTietKhungHocKy_TinChiController(IChiTietKhungHocKy_TinChiService service) : base(service)
    {
        _service = service;
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.ChuongTrinhKhungTinChi)
            .ThenInclude(x => x.CoSoDaoTao)
            .Include(x => x.ChuongTrinhKhungTinChi)
            .ThenInclude(x => x.LoaiDaoTao)
            .Include(x => x.ChuongTrinhKhungTinChi)
            .ThenInclude(x => x.KhoaHoc)
            .Include(x => x.ChuongTrinhKhungTinChi)
            .ThenInclude(x => x.NganhHoc)
            .Include(x => x.ChuongTrinhKhungTinChi)
            .ThenInclude(x => x.BacDaoTao)
            .Include(x => x.MonHocBacDaoTao)
            .ThenInclude(x => x.BacDaoTao)
        );
        return result.ToResult();
    }

    [HttpGet("get-hoc-ky")]
    public async Task<IActionResult> GetAllHocKy()
    {
        var result = await _service.GetAllHocKyAsync();
        return result.ToResult();
    }

    [HttpGet("chuong-trinh-khung-mon-hoc-pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] SinhVienMienMonHocFilterDto filter)
    {
        var result = await _service.GetChuongTrinhKhungMonHocPagination(request, filter);
        return result.ToResult();
    }
}