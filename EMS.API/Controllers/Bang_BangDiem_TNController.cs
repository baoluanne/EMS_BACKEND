using EMS.Application.Services.Bang_BangDiem_TNServices;
using EMS.Domain.Entities;
using EMS.API.Controllers.Base;

namespace EMS.API.Controllers;

public class Bang_BangDiem_TNController : BaseController<Bang_BangDiem_TN>
{
    public Bang_BangDiem_TNController(IBang_BangDiem_TNService bang_BangDiem_TNService) : base(bang_BangDiem_TNService)
    {
    }
} 