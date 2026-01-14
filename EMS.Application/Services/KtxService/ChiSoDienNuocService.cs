using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.KtxService;

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

    public async Task<Result<ChiSoDienNuocPagingResponse>> GetPaginatedAsync(PaginationRequest request, ChiSoDienNuocFilter filter)
    {
        var predicate = PredicateBuilder.New<KtxChiSoDienNuoc>(true);

        if (filter.Thang.HasValue) predicate = predicate.And(q => q.Thang == filter.Thang.Value);
        if (filter.Nam.HasValue) predicate = predicate.And(q => q.Nam == filter.Nam.Value);
        if (filter.ToaNhaId.HasValue) predicate = predicate.And(q => q.PhongKtx!.ToaNhaId == filter.ToaNhaId.Value);
        if (filter.PhongId.HasValue) predicate = predicate.And(q => q.PhongKtxId == filter.PhongId.Value);
        if (filter.DaChot.HasValue) predicate = predicate.And(q => q.DaChot == filter.DaChot.Value);

        var (data, total) = await _repository.GetPaginatedWithDetailsAsync(request, predicate);

        return new Result<ChiSoDienNuocPagingResponse>(new ChiSoDienNuocPagingResponse { Data = data, Total = total });
    }
}