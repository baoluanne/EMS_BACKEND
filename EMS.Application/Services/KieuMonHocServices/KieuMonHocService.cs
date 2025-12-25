using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.KieuMonHocServices
{
    public class KieuMonHocService : BaseService<KieuMonHoc>, IKieuMonHocService
    {
        public KieuMonHocService(IUnitOfWork unitOfWork, IKieuMonHocRepository kieuMonHocRepository) 
            : base(unitOfWork, kieuMonHocRepository)
        {
        }

        protected override Task UpdateEntityProperties(KieuMonHoc existingEntity, KieuMonHoc newEntity)
        {
            existingEntity.MaKieuMonHoc = newEntity.MaKieuMonHoc;
            existingEntity.TenKieuMonHoc = newEntity.TenKieuMonHoc;
            existingEntity.GhiChu = newEntity.GhiChu;

            return Task.CompletedTask;
        }
    }
} 