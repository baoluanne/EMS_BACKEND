using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.NoiDungServices;

public class NoiDungService : BaseService<NoiDung>, INoiDungService
{
    public NoiDungService(IUnitOfWork unitOfWork, INoiDungRepository noiDungRepository)
            : base(unitOfWork, noiDungRepository)
    {
    }

    protected override Task UpdateEntityProperties(NoiDung existingEntity, NoiDung newEntity)
    {
        existingEntity.TenNoiDung = newEntity.TenNoiDung;
        return Task.CompletedTask;
    }
}
