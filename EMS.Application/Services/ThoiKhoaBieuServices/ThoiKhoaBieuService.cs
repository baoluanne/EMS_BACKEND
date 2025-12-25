using EMS.Application.Services.Base;
using EMS.Application.Services.ThoiGianDaoTao_Services;
using EMS.Domain.Entities;
using EMS.Domain.Entities.TimeTable;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.TimeTable;

namespace EMS.Application.Services.ThoiKhoaBieuServices;

public class ThoiKhoaBieuService : BaseService<ThoiKhoaBieu>, IThoiKhoaBieuService
{
    public ThoiKhoaBieuService(IUnitOfWork unitOfWork, IThoiKhoaBieuRepository tkbTaoRepository) 
        : base(unitOfWork, tkbTaoRepository)
    {
    }

    protected override Task UpdateEntityProperties(ThoiKhoaBieu existingEntity, ThoiKhoaBieu newEntity)
    {
        existingEntity.IdLopHocPhan = existingEntity.IdLopHocPhan;
        existingEntity.IdPhongHoc = existingEntity.IdPhongHoc;
        existingEntity.IdGiangVien = existingEntity.IdGiangVien;
        existingEntity.TietBatDau = existingEntity.TietBatDau;
        existingEntity.SoTiet = existingEntity.SoTiet;
        existingEntity.Thu = existingEntity.Thu;
        existingEntity.TuanHoc = existingEntity.TuanHoc;
        existingEntity.GhiChu = existingEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 