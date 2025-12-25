using EMS.API.Controllers.Base;
using EMS.Application.Services.ThoiGianDaoTao_Services;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class ThoiGianDaoTaoController : BaseController<ThoiGianDaoTao>
{
    public ThoiGianDaoTaoController(IThoiGianDaoTaoService thoiGianDaoTaoService) : base(thoiGianDaoTaoService)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.BacDaoTao)
            .Include(x => x.LoaiDaoTao)
            .Include(x => x.BangDiemTN)
            .Include(x => x.BangTotNghiep)
            .Include(x => x.KhoiNganh));
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowerCaseKeyword = keyword?.ToLower();
        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q
                .Include(x => x.BacDaoTao)
                .Include(x => x.LoaiDaoTao)
                .Include(x => x.BangDiemTN)
                .Include(x => x.BangTotNghiep)
                .Include(x => x.KhoiNganh),
            filter: q => string.IsNullOrEmpty(lowerCaseKeyword)
                         || (q.BacDaoTao != null && q.BacDaoTao.TenBacDaoTao.ToLower().Contains(lowerCaseKeyword))
                         || (q.LoaiDaoTao != null && q.LoaiDaoTao.TenLoaiDaoTao.ToLower().Contains(lowerCaseKeyword))
                         || (q.KhoiNganh != null && q.KhoiNganh.TenKhoiNganh.ToLower().Contains(lowerCaseKeyword))
                         || (q.ThoiGianKeHoach != null && q.ThoiGianKeHoach.ToString()!.ToLower().Contains(lowerCaseKeyword))
                         || (q.ThoiGianToiThieu != null && q.ThoiGianToiThieu.ToString()!.ToLower().Contains(lowerCaseKeyword))
                         || (q.ThoiGianToiDa != null && q.ThoiGianToiDa.ToString()!.ToLower().Contains(lowerCaseKeyword))
                         || (!string.IsNullOrEmpty(q.HanCheDKHP) && q.HanCheDKHP.ToLower().Contains(lowerCaseKeyword))
                         || (!string.IsNullOrEmpty(q.GiayBaoTrungTuyen) && q.GiayBaoTrungTuyen.ToLower().Contains(lowerCaseKeyword))
                         || (q.HeSoDaoTao != null && q.HeSoDaoTao.ToString()!.ToLower().Contains(lowerCaseKeyword))
                         || (!string.IsNullOrEmpty(q.KyTuMaSV) && q.KyTuMaSV.ToLower().Contains(lowerCaseKeyword))
                         || (!string.IsNullOrEmpty(q.GhiChu) && q.GhiChu.ToLower().Contains(lowerCaseKeyword))
                         || (q.BangTotNghiep != null && q.BangTotNghiep.TenBang_BangDiem.ToLower().Contains(lowerCaseKeyword)));

        return result.ToResult();
    }
}