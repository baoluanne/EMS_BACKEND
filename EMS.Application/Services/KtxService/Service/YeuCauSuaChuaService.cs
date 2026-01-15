using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;

namespace EMS.Application.Services.KtxService.Service;

public class YeuCauSuaChuaService : BaseService<KtxYeuCauSuaChua>, IYeuCauSuaChuaService
{
    private readonly IYeuCauSuaChuaRepository _repository;

    public YeuCauSuaChuaService(IUnitOfWork unitOfWork, IYeuCauSuaChuaRepository repository)
        : base(unitOfWork, repository)
    {
        _repository = repository;
    }

    protected override Task UpdateEntityProperties(KtxYeuCauSuaChua existingEntity, KtxYeuCauSuaChua newEntity)
    {
        existingEntity.TieuDe = newEntity.TieuDe;
        existingEntity.NoiDung = newEntity.NoiDung;
        existingEntity.TrangThai = newEntity.TrangThai;
        existingEntity.GhiChuXuLy = newEntity.GhiChuXuLy;
        existingEntity.ChiPhiPhatSinh = newEntity.ChiPhiPhatSinh;
        existingEntity.NgayGui = newEntity.NgayGui;
        existingEntity.NgayXuLy = newEntity.NgayXuLy;
        existingEntity.NgayHoanThanh = newEntity.NgayHoanThanh;
        existingEntity.SinhVienId = newEntity.SinhVienId;
        existingEntity.PhongKtxId = newEntity.PhongKtxId;
        return Task.CompletedTask;
    }
}