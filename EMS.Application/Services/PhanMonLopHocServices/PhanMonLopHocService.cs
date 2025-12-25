using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.PhanMonLopHocServices
{
    public class PhanMonLopHocService : BaseService<PhanMonLopHoc>, IPhanMonLopHocService
    {
        public PhanMonLopHocService(IUnitOfWork unitOfWork, IPhanMonLopHocRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(PhanMonLopHoc existingEntity, PhanMonLopHoc newEntity)
        {
            existingEntity.IdMonHocBacDaoTao = newEntity.IdMonHocBacDaoTao;
            existingEntity.MonHocBacDaoTao = newEntity.MonHocBacDaoTao;
            existingEntity.IdLopNienChe = newEntity.IdLopNienChe;
            existingEntity.HocKy = newEntity.HocKy;
            existingEntity.IsVisible = newEntity.IsVisible;
            existingEntity.GhiChu = newEntity.GhiChu;

            return Task.CompletedTask;
        }
    }
} 