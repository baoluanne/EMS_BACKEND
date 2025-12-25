using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.TieuChuanXetHocBongServices;

public class TieuChuanXetHocBongService : BaseService<TieuChuanXetHocBong>, ITieuChuanXetHocBongService
{
    public TieuChuanXetHocBongService(IUnitOfWork unitOfWork, ITieuChuanXetHocBongRepository tieuChuanXetHocBongRepository) 
        : base(unitOfWork, tieuChuanXetHocBongRepository)
    {
    }

    protected override Task UpdateEntityProperties(TieuChuanXetHocBong existingEntity, TieuChuanXetHocBong newEntity)
    {
        existingEntity.STT = newEntity.STT;
        existingEntity.Nhom = newEntity.Nhom;
        existingEntity.HocBong = newEntity.HocBong;
        existingEntity.HocLucDiem10Tu = newEntity.HocLucDiem10Tu;
        existingEntity.HocLucDiem10Den = newEntity.HocLucDiem10Den;
        existingEntity.HocLucDiem4Tu = newEntity.HocLucDiem4Tu;
        existingEntity.HocLucDiem4Den = newEntity.HocLucDiem4Den;
        existingEntity.HanhKiemTu = newEntity.HanhKiemTu;
        existingEntity.HanhKiemDen = newEntity.HanhKiemDen;
        existingEntity.SoTien = newEntity.SoTien;
        existingEntity.PhanTramSoTien = newEntity.PhanTramSoTien;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 