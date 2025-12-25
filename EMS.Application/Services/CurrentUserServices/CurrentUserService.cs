using System.Security.Claims;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;

namespace EMS.Application.Services.CurrentUserServices;

public class CurrentUserService(
    IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork
) : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly INguoiDungRepository _nguoiDungRepository = unitOfWork.GetRepository<INguoiDungRepository>();

    public Guid? GetUserId()
    {
        var value = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        return value is not null ? Guid.Parse(value) : null;
    }

    public string? GetUserEmail()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
    }

    public async Task<NguoiDung?> GetCurrentUser()
    {
        var userId = GetUserId();
        if (userId == null)
        {
            return null;
        }

        return await _nguoiDungRepository.GetByIdAsync(userId);
    }
}
