using EMS.API.Controllers.Base;
using EMS.Application.Services.KeHoachDaoTao_NienCheServices;
using EMS.Application.Services.KeHoachDaoTao_NienCheServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class KeHoachDaoTao_NienCheController : BaseController<KeHoachDaoTao_NienChe>
{
    public KeHoachDaoTao_NienCheController(IKeHoachDaoTao_NienCheService service) : base(service)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.HocKy).ThenInclude(x => x.NamHoc)
            .Include(x => x.ChiTietChuongTrinhKhung_NienChe)
            .Include(x => x.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe)
            .Include(x => x.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe.KhoaHoc)
            .Include(x => x.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe.BacDaoTao)
            .Include(x => x.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe.LoaiDaoTao)
            .Include(x => x.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe.NganhHoc)
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
                .Include(x => x.ChiTietChuongTrinhKhung_NienChe)
                .Include(x => x.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe)
                .Include(x => x.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe.KhoaHoc)
                .Include(x => x.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe.BacDaoTao)
                .Include(x => x.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe.LoaiDaoTao)
                .Include(x => x.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe.NganhHoc),
            filter: q =>
                (filter.IdBacDaoTao == null
                    || (q.ChiTietChuongTrinhKhung_NienChe != null
                        && q.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe != null
                        && q.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe.IdBacDaoTao == filter.IdBacDaoTao))
                && (filter.IdCoSoDaoTao == null
                    || (q.ChiTietChuongTrinhKhung_NienChe != null
                        && q.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe != null
                        && q.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe.IdCoSoDaoTao == filter.IdCoSoDaoTao))
                && (filter.IdKhoaHoc == null
                    || (q.ChiTietChuongTrinhKhung_NienChe != null
                        && q.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe != null
                        && q.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe.IdKhoaHoc == filter.IdKhoaHoc))
                && (filter.IdLoaiDaoTao == null
                    || (q.ChiTietChuongTrinhKhung_NienChe != null
                        && q.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe != null
                        && q.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe.IdLoaiDaoTao == filter.IdLoaiDaoTao))
                && (filter.IdNganhHoc == null
                    || (q.ChiTietChuongTrinhKhung_NienChe != null
                        && q.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe != null
                        && q.ChiTietChuongTrinhKhung_NienChe.ChuongTrinhKhungNienChe.IdNganhHoc == filter.IdNganhHoc))
                && (filter.IdHocKy == null || q.IdHocKy == filter.IdHocKy)
        );
        return result.ToResult();
    }
} 