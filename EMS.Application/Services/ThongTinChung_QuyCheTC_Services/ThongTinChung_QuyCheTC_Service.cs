using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.ThongTinChung_QuyCheTC_Services;

public class ThongTinChung_QuyCheTC_Service : BaseService<ThongTinChung_QuyCheTC>, IThongTinChung_QuyCheTC_Service
{
    public ThongTinChung_QuyCheTC_Service(IUnitOfWork unitOfWork, IThongTinChung_QuyCheTC_Repository thongTinChung_QuyCheTC_Repository) 
        : base(unitOfWork, thongTinChung_QuyCheTC_Repository)
    {
    }

    protected override Task UpdateEntityProperties(ThongTinChung_QuyCheTC existingEntity, ThongTinChung_QuyCheTC newEntity)
    {
        existingEntity.IdQuyCheTC = newEntity.IdQuyCheTC;
        existingEntity.DiemTKTrongSo = newEntity.DiemTKTrongSo;
        existingEntity.DiemGKTrongSo = newEntity.DiemGKTrongSo;
        existingEntity.DiemTieuLuanTrongSo = newEntity.DiemTieuLuanTrongSo;
        existingEntity.DiemCuoiKyTrongSo = newEntity.DiemCuoiKyTrongSo;
        
        return Task.CompletedTask;
    }
} 