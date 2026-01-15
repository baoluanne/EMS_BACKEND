using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using LinqKit;
using System.Linq.Expressions;

namespace EMS.Application.Services.KtxService.Service;

public class ToaNhaKtxService : BaseService<KTXToaNha>, IToaNhaKtxService
{
    private readonly IToaNhaKtxRepository _repository;

    public ToaNhaKtxService(IUnitOfWork unitOfWork, IToaNhaKtxRepository repository)
        : base(unitOfWork, repository)
    {
        _repository = repository;
    }

    protected override Task UpdateEntityProperties(KTXToaNha existingEntity, KTXToaNha newEntity)
    {
        existingEntity.TenToaNha = newEntity.TenToaNha;
        existingEntity.LoaiToaNha = newEntity.LoaiToaNha;
        existingEntity.SoTang = newEntity.SoTang;
        existingEntity.GhiChu = newEntity.GhiChu;
        return Task.CompletedTask;
    }
}