using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhSachKhoaSuDungServices;

public class DanhSachKhoaSuDungService : BaseService<DanhSachKhoaSuDung>, IDanhSachKhoaSuDungService
{
    public DanhSachKhoaSuDungService(IUnitOfWork unitOfWork, IDanhSachKhoaSuDungRepository danhSachKhoaSuDungRepository) 
        : base(unitOfWork, danhSachKhoaSuDungRepository)
    {
    }

    protected override Task UpdateEntityProperties(DanhSachKhoaSuDung existingEntity, DanhSachKhoaSuDung newEntity)
    {
        existingEntity.IdPhong = newEntity.IdPhong;
        existingEntity.IdKhoaSuDung = newEntity.IdKhoaSuDung;
        existingEntity.GhiChu = newEntity.GhiChu;
        
        return Task.CompletedTask;
    }
} 