using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhMucPhongBanServices;

public class DanhMucPhongBanService : BaseService<DanhMucPhongBan>, IDanhMucPhongBanService
{
    public DanhMucPhongBanService(IUnitOfWork unitOfWork, IDanhMucPhongBanRepository danhMucPhongBanRepository) 
        : base(unitOfWork, danhMucPhongBanRepository)
    {
    }

    protected override Task UpdateEntityProperties(DanhMucPhongBan existingEntity, DanhMucPhongBan newEntity)
    {
        existingEntity.MaPhongBan = newEntity.MaPhongBan;
        existingEntity.TenPhongBan = newEntity.TenPhongBan;
        existingEntity.IsDaoTao = newEntity.IsDaoTao;
        
        return Task.CompletedTask;
    }
} 