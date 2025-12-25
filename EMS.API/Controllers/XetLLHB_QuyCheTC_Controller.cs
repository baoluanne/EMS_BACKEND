using EMS.Application.Services.XetLLHB_QuyCheTC_Services;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class XetLLHB_QuyCheTC_Controller : BaseController<XetLLHB_QuyCheTC>
{
    public XetLLHB_QuyCheTC_Controller(IXetLLHB_QuyCheTC_Service xetLLHB_QuyCheTC_Service) : base(xetLLHB_QuyCheTC_Service)
    {
    }
} 