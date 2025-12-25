using EMS.Domain.Entities;

namespace EMS.Application.Services.CurrentUserServices;

public interface ICurrentUserService
{
    public Guid? GetUserId();

    public string? GetUserEmail();

    Task<NguoiDung?> GetCurrentUser();
}
