using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.KtxService.Service;

public class ChiSoDienNuocService : BaseService<KtxChiSoDienNuoc>, IChiSoDienNuocService
{
    private readonly IChiSoDienNuocRepository _repository;

    public ChiSoDienNuocService(IUnitOfWork unitOfWork, IChiSoDienNuocRepository repository)
        : base(unitOfWork, repository)
    {
        _repository = repository;
    }

    protected override Task UpdateEntityProperties(KtxChiSoDienNuoc existingEntity, KtxChiSoDienNuoc newEntity)
    {
        existingEntity.PhongKtxId = newEntity.PhongKtxId;
        existingEntity.Thang = newEntity.Thang;
        existingEntity.Nam = newEntity.Nam;
        existingEntity.DienCu = newEntity.DienCu;
        existingEntity.DienMoi = newEntity.DienMoi;
        existingEntity.NuocCu = newEntity.NuocCu;
        existingEntity.NuocMoi = newEntity.NuocMoi;
        existingEntity.DaChot = newEntity.DaChot;
        return Task.CompletedTask;
    }
}
