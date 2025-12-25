using EMS.API.Controllers.Base;
using EMS.Application.Services.BacDaoTaoServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class BacDaoTaoController : BaseController<BacDaoTao>
{
    public BacDaoTaoController(IBacDaoTaoService bacDaoTaoService) : base(bacDaoTaoService)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync();
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPagination(
        [FromQuery] PaginationRequest request,
        [FromQuery] string? keyword)
    {
        var lowercaseKeyword = keyword?.ToLower();

        var result = await Service.GetPaginatedAsync(
            request,
            filter: q =>
                string.IsNullOrEmpty(lowercaseKeyword)
                || q.TenBacDaoTao.ToLower().Contains(lowercaseKeyword.ToLower())
                || (!string.IsNullOrEmpty(q.TenTiengAnh) &&
                    q.TenTiengAnh.ToLower().Contains(lowercaseKeyword.ToLower()))
                || (q.STT != null && q.STT.ToString()!.ToLower().Contains(lowercaseKeyword.ToLower()))
                || q.MaBacDaoTao.ToLower().Contains(lowercaseKeyword.ToLower())
                || (!string.IsNullOrEmpty(q.GhiChu) && q.GhiChu.ToLower().Contains(lowercaseKeyword))
                || (!string.IsNullOrEmpty(q.HinhThucDaoTao) && q.HinhThucDaoTao.ToLower().Contains(lowercaseKeyword.ToLower()))
                || (!string.IsNullOrEmpty(q.TenLoaiBangCapTN) && q.TenLoaiBangCapTN.ToLower().Contains(lowercaseKeyword))
                || (!string.IsNullOrEmpty(q.TenLoaiBangCapTN_ENG) && q.TenLoaiBangCapTN_ENG.ToLower().Contains(lowercaseKeyword))
                || (!string.IsNullOrEmpty(q.PhongBanKyBM) && q.PhongBanKyBM.ToLower().Contains(lowercaseKeyword))
        );

        return result.ToResult();
    }
}