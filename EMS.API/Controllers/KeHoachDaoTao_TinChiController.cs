using EMS.API.Controllers.Base;
using EMS.Application.Services.KeHoachDaoTao_NienCheServices.Dtos;
using EMS.Application.Services.KeHoachDaoTao_TinChiServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class KeHoachDaoTao_TinChiController : BaseController<KeHoachDaoTao_TinChi>
{
    public KeHoachDaoTao_TinChiController(IKeHoachDaoTao_TinChiService service) : base(service)
    {
    }
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.HocKy).ThenInclude(x => x.NamHoc)
            .Include(x => x.ChiTietKhungHocKy_TinChi)
            .Include(x => x.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi)
            .Include(x => x.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi.KhoaHoc)
            .Include(x => x.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi.BacDaoTao)
            .Include(x => x.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi.LoaiDaoTao)
            .Include(x => x.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi.NganhHoc)
        );
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] KeHoachDaoTaoFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q
                .Include(x => x.HocKy).ThenInclude(x => x.NamHoc)
                .Include(x => x.ChiTietKhungHocKy_TinChi)
                .Include(x => x.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi)
                .Include(x => x.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi.KhoaHoc)
                .Include(x => x.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi.BacDaoTao)
                .Include(x => x.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi.LoaiDaoTao)
                .Include(x => x.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi.NganhHoc),
            filter: q =>
                (filter.IdBacDaoTao == null
                    || (q.ChiTietKhungHocKy_TinChi != null
                        && q.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi != null
                        && q.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi.IdBacDaoTao == filter.IdBacDaoTao))
                && (filter.IdCoSoDaoTao == null
                    || (q.ChiTietKhungHocKy_TinChi != null
                        && q.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi != null
                        && q.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi.IdCoSoDaoTao == filter.IdCoSoDaoTao))
                && (filter.IdKhoaHoc == null
                    || (q.ChiTietKhungHocKy_TinChi != null
                        && q.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi != null
                        && q.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi.IdKhoaHoc == filter.IdKhoaHoc))
                && (filter.IdLoaiDaoTao == null
                    || (q.ChiTietKhungHocKy_TinChi != null
                        && q.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi != null
                        && q.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi.IdLoaiDaoTao == filter.IdLoaiDaoTao))
                && (filter.IdNganhHoc == null
                    || (q.ChiTietKhungHocKy_TinChi != null
                        && q.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi != null
                        && q.ChiTietKhungHocKy_TinChi.ChuongTrinhKhungTinChi.IdNganhHoc == filter.IdNganhHoc))
                && (filter.IdHocKy == null || q.IdHocKy == filter.IdHocKy)
        );
        return result.ToResult();
    }
}