using EMS.Application.Services.ThongTinChung_QuyCheTC_Services;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class ThongTinChung_QuyCheTC_Controller : BaseController<ThongTinChung_QuyCheTC>
{
    public ThongTinChung_QuyCheTC_Controller(IThongTinChung_QuyCheTC_Service thongTinChung_QuyCheTC_Service) : base(thongTinChung_QuyCheTC_Service)
    {
    }
} 