using System.Linq.Expressions;
using EMS.API.Controllers.Base;
using EMS.Application.Services.LoaiDaoTaoServices.Dtos;
using EMS.Application.Services.QuyUocCotDiem_TC_Services;
using EMS.Application.Services.QuyUocCotDiem_TC_Services.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers;

public class QuyUocCotDiem_TC_Controller : BaseController<QuyUocCotDiem_TC>
{
    public QuyUocCotDiem_TC_Controller(IQuyUocCotDiem_TC_Service quyUocCotDiem_TC_Service) : base(quyUocCotDiem_TC_Service)
    {
    }
    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.QuyChe_TinChi)
                .ThenInclude(x => x.QuyCheHocVu)
            .Include(x => x.KieuMon)
            .Include(x => x.KieuLamTron)
        );
        return result.ToResult();
    }

    [HttpGet("pagination")]
    public virtual async Task<IActionResult> GetPaginated(
        [FromQuery] PaginationRequest request,
        [FromQuery] QuyUocCotDiemFilter filter)
    {
        var result = await Service.GetPaginatedAsync(
            request,
            include: q => q.Include(x => x.QuyChe_TinChi)
                    .ThenInclude(x => x.QuyCheHocVu)
                .Include(x => x.KieuMon)
                .Include(x => x.KieuLamTron),
            filter: q =>
                (filter.IdQuyChe == null || q.IdQuyChe_TinChi == filter.IdQuyChe)
                && (filter.IdKieuMon == null || q.IdKieuMon == filter.IdKieuMon)
                && (filter.IdKieuLamTron == null || q.IdKieuLamTron == filter.IdKieuLamTron)
                && (string.IsNullOrEmpty(filter.QuyUoc) ||
                    q.TenQuyUoc.ToLower().Contains(filter.QuyUoc.ToLower()))
        );
        return result.ToResult();
    }
}