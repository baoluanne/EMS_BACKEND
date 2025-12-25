using EMS.API.Controllers.Base;
using EMS.Application.Services.ChiTietChuongTrinhKhung_NienCheServices;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class ChiTietChuongTrinhKhung_NienCheController : BaseController<ChiTietChuongTrinhKhung_NienChe>
{
    public ChiTietChuongTrinhKhung_NienCheController(IChiTietChuongTrinhKhung_NienCheService service) : base(service)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.ChuongTrinhKhungNienChe)
            .ThenInclude(x => x.CoSoDaoTao)
            .Include(x => x.ChuongTrinhKhungNienChe)
            .ThenInclude(x => x.LoaiDaoTao)
            .Include(x => x.ChuongTrinhKhungNienChe)
            .ThenInclude(x => x.KhoaHoc)
            .Include(x => x.ChuongTrinhKhungNienChe)
            .ThenInclude(x => x.NganhHoc)
            .Include(x => x.ChuongTrinhKhungNienChe)
            .ThenInclude(x => x.BacDaoTao)
            .Include(x => x.MonHocBacDaoTao)
            .ThenInclude(x => x.BacDaoTao)
        );
        return result.ToResult();
    }
}