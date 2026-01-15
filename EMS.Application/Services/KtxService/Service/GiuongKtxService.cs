using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.KtxService.Service;

public class GiuongKtxService : BaseService<KtxGiuong>, IGiuongKtxService
{
    private readonly IGiuongKtxRepository _repository;

    public GiuongKtxService(IUnitOfWork unitOfWork, IGiuongKtxRepository repository)
        : base(unitOfWork, repository)
    {
        _repository = repository;
    }

    protected override Task UpdateEntityProperties(KtxGiuong existingEntity, KtxGiuong newEntity)
    {
        existingEntity.MaGiuong = newEntity.MaGiuong;
        existingEntity.SinhVienId = newEntity.SinhVienId;
        existingEntity.PhongKtxId = newEntity.PhongKtxId;
        return Task.CompletedTask;
    }
}