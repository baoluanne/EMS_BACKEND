using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.KeHoachDaoTao_NienCheServices
{
    public class KeHoachDaoTao_NienCheService : BaseService<KeHoachDaoTao_NienChe>, IKeHoachDaoTao_NienCheService
    {
        public KeHoachDaoTao_NienCheService(IUnitOfWork unitOfWork, IKeHoachDaoTao_NienCheRepository repository)
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(KeHoachDaoTao_NienChe existingEntity, KeHoachDaoTao_NienChe newEntity)
        {
            existingEntity.IdChiTietKhungHocKy_NienChe = newEntity.IdChiTietKhungHocKy_NienChe;
            existingEntity.IdHocKy = newEntity.IdHocKy;
            existingEntity.IsHocKyChinh = newEntity.IsHocKyChinh;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
} 