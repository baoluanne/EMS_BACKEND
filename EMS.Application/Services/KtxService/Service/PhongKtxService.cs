using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService.Service;

public class PhongKtxService : BaseService<KtxPhong>, IPhongKtxService
{
    private readonly IPhongKtxRepository _repository;

    public PhongKtxService(IUnitOfWork unitOfWork, IPhongKtxRepository repository)
        : base(unitOfWork, repository)
    {
        _repository = repository;
    }

    protected override Task UpdateEntityProperties(KtxPhong existingEntity, KtxPhong newEntity)
    {
        existingEntity.TangKtxId = newEntity.TangKtxId;
        existingEntity.MaPhong = newEntity.MaPhong;
        existingEntity.SoLuongGiuong = newEntity.SoLuongGiuong;
        existingEntity.LoaiPhong = newEntity.LoaiPhong;
        return Task.CompletedTask;
    }
}
