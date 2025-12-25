using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LyDoXinPhongServices;

public class LyDoXinPhongService : BaseService<LyDoXinPhong>, ILyDoXinPhongService
{
    public LyDoXinPhongService(IUnitOfWork unitOfWork, ILyDoXinPhongRepository lyDoXinPhongRepository) 
        : base(unitOfWork, lyDoXinPhongRepository)
    {
    }

    protected override Task UpdateEntityProperties(LyDoXinPhong existingEntity, LyDoXinPhong newEntity)
    {
        existingEntity.MaLoaiXinPhong = newEntity.MaLoaiXinPhong;
        existingEntity.TenLoaiXinPhong = newEntity.TenLoaiXinPhong;
        existingEntity.SoThuTu = newEntity.SoThuTu;
        
        return Task.CompletedTask;
    }
} 