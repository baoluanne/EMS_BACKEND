using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.HocViServices
{
    public class HocViService : BaseService<HocVi>, IHocViService
    {
        public HocViService(IUnitOfWork unitOfWork, IHocViRepository hocViRepository) 
            : base(unitOfWork, hocViRepository)
        {
        }

        protected override Task UpdateEntityProperties(HocVi existingEntity, HocVi newEntity)
        {
            existingEntity.MaHocVi = newEntity.MaHocVi;
            existingEntity.TenHocVi = newEntity.TenHocVi;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
} 