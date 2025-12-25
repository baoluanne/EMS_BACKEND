using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;
using EMS.Application.Services.QuyUocCotDiem_MonHocServices;
using EMS.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers;

public class QuyUocCotDiem_MonHocController : BaseController<QuyUocCotDiem_MonHoc>
{
    public QuyUocCotDiem_MonHocController(IQuyUocCotDiem_MonHocService service) : base(service)
    {
    }
} 