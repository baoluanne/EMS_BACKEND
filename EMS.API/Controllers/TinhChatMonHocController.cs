using EMS.API.Controllers.Base;
using EMS.Application.Services.TinhChatMonHocServices;
using EMS.Domain.Entities;

namespace EMS.API.Controllers;

public class TinhChatMonHocController : BaseController<TinhChatMonHoc>
{
    public TinhChatMonHocController(ITinhChatMonHocService toBoMonService) : base(toBoMonService)
    {
    }
}  