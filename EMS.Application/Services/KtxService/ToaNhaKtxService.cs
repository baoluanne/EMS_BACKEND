using EMS.Application.DTOs.KtxManagement;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using LinqKit;
using System.Linq.Expressions;

namespace EMS.Application.Services.KtxService;

public class ToaNhaKtxService : BaseService<ToaNhaKtx>, IToaNhaKtxService
{
    public ToaNhaKtxService(
         IUnitOfWork unitOfWork,
         IToaNhaKtxRepository repository)
         : base(unitOfWork, repository)
    {
    }

    protected override Task UpdateEntityProperties(ToaNhaKtx existingEntity, ToaNhaKtx newEntity)
    {
        existingEntity.TenToaNha = newEntity.TenToaNha;
        existingEntity.LoaiToaNha = newEntity.LoaiToaNha;
        return Task.CompletedTask;
    }
}