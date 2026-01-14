using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService;

public class PhongKtxService(
    IUnitOfWork unitOfWork,
    IPhongKtxRepository phongRepository,
    IGiuongKtxRepository giuongRepository)
    : BaseService<KtxPhong>(unitOfWork, phongRepository), IPhongKtxService
{
    protected override Task UpdateEntityProperties(KtxPhong existingEntity, KtxPhong newEntity)
    {
        existingEntity.MaPhong = newEntity.MaPhong;
        existingEntity.ktxToaNhaId = newEntity.ToaNhaId;
        existingEntity.SoLuongGiuong = newEntity.SoLuongGiuong;
        existingEntity.SoLuongDaO = newEntity.SoLuongDaO;
        existingEntity.TrangThai = newEntity.TrangThai;
        existingEntity.GiaPhong = newEntity.GiaPhong;
        return Task.CompletedTask;
    }
}