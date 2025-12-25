using EMS.Domain.Entities;
using EMS.Domain.Interfaces.Repositories;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;

namespace EMS.Infrastructure.Repositories;

public class NguoiDungRepository(DbFactory dbFactory) : AuditRepository<NguoiDung>(dbFactory), INguoiDungRepository
{
    public async Task<NguoiDung?> GetNguoiDungByEmailAsync(string email)
    {
        var nguoiDung = await GetFirstNotDeletedAsync(x => x.Email == email);

        return nguoiDung;
    }
}
