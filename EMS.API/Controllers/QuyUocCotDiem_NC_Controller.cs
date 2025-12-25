using EMS.Application.Services.QuyUocCotDiem_NC_Services;
using EMS.Domain.Entities;
using EMS.Domain.Extensions;
using EMS.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMS.Application.Services.QuyUocCotDiem_TC_Services.Dtos;
using EMS.Domain.Models;

namespace EMS.API.Controllers;

public class QuyUocCotDiem_NC_Controller : BaseController<QuyUocCotDiem_NC>
{
    public QuyUocCotDiem_NC_Controller(IQuyUocCotDiem_NC_Service quyUocCotDiem_NC_Service) : base(quyUocCotDiem_NC_Service)
    {
    }

    public override async Task<IActionResult> GetAll()
    {
        var result = await Service.GetAllAsync(q => q
            .Include(x => x.QuyChe_NienChe)
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
            include: q => q.Include(x => x.QuyChe_NienChe)
                    .ThenInclude(x => x.QuyCheHocVu)
                .Include(x => x.KieuMon)
                .Include(x => x.KieuLamTron),
            filter: q =>
                (filter.IdQuyChe == null || q.IdQuyChe_NienChe == filter.IdQuyChe)
                && (filter.IdKieuMon == null || q.IdKieuMon == filter.IdKieuMon)
                && (filter.IdKieuLamTron == null || q.IdKieuLamTron == filter.IdKieuLamTron)
                && (string.IsNullOrEmpty(filter.QuyUoc) ||
                    q.TenQuyUoc.ToLower().Contains(filter.QuyUoc.ToLower()))
        );
        return result.ToResult();
    }
} 