using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LopNienCheServices;

public class LopNienCheService : BaseService<LopNienChe>, ILopNienCheService
{
    public LopNienCheService(IUnitOfWork unitOfWork, ILopNienCheRepository lopNienCheRepository) 
        : base(unitOfWork, lopNienCheRepository)
    {
    }

    protected override Task UpdateEntityProperties(LopNienChe existingEntity, LopNienChe newEntity)
    {
        existingEntity.MaLop = newEntity.MaLop;
        existingEntity.TenLop = newEntity.TenLop;
        existingEntity.IsVisible = newEntity.IsVisible;
        existingEntity.IdCoSoDaoTao = newEntity.IdCoSoDaoTao;
        existingEntity.IdBacDaoTao = newEntity.IdBacDaoTao;
        existingEntity.IdLoaiDaoTao = newEntity.IdLoaiDaoTao;
        existingEntity.IdKhoaHoc = newEntity.IdKhoaHoc;
        existingEntity.IdNganh = newEntity.IdNganh;
        existingEntity.IdChuyenNganh = newEntity.IdChuyenNganh;
        
        return Task.CompletedTask;
    }
} 