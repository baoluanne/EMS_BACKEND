using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.KeHoachDaoTao_TinChiServices
{
    public class KeHoachDaoTao_TinChiService : BaseService<KeHoachDaoTao_TinChi>, IKeHoachDaoTao_TinChiService
    {
        public KeHoachDaoTao_TinChiService(IUnitOfWork unitOfWork, IKeHoachDaoTao_TinChiRepository repository)
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(KeHoachDaoTao_TinChi existingEntity, KeHoachDaoTao_TinChi newEntity)
        {
            existingEntity.IdChiTietKhungHocKy_TinChi = newEntity.IdChiTietKhungHocKy_TinChi;
            existingEntity.IdHocKy = newEntity.IdHocKy;
            existingEntity.IsHocKyChinh = newEntity.IsHocKyChinh;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
} 