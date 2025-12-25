using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.TieuChuanXetDanhHieuServices;

public class TieuChuanXetDanhHieuService : BaseService<TieuChuanXetDanhHieu>, ITieuChuanXetDanhHieuService
{
    public TieuChuanXetDanhHieuService(IUnitOfWork unitOfWork, ITieuChuanXetDanhHieuRepository tieuChuanXetDanhHieuRepository) 
        : base(unitOfWork, tieuChuanXetDanhHieuRepository)
    {
    }

    protected override Task UpdateEntityProperties(TieuChuanXetDanhHieu existingEntity, TieuChuanXetDanhHieu newEntity)
    {
        existingEntity.STT = newEntity.STT;
        existingEntity.NhomDanhHieu = newEntity.NhomDanhHieu;
        existingEntity.HocLuc10Tu = newEntity.HocLuc10Tu;
        existingEntity.HocLuc10Den = newEntity.HocLuc10Den;
        existingEntity.HocLuc4Tu = newEntity.HocLuc4Tu;
        existingEntity.HocLuc4Den = newEntity.HocLuc4Den;
        existingEntity.HanhKiemTu = newEntity.HanhKiemTu;
        existingEntity.HanhKiemDen = newEntity.HanhKiemDen;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 