using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories.Base;

namespace EMS.Domain.Interfaces.Repositories;

public interface INguoiDungRepository : IAuditRepository<NguoiDung>
{
    Task<NguoiDung?> GetNguoiDungByEmailAsync(string email);
}
