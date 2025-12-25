using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.ApDungQuyCheHocVuServices
{
    public class ApDungQuyCheHocVuService : BaseService<ApDungQuyCheHocVu>, IApDungQuyCheHocVuService
    {
        public ApDungQuyCheHocVuService(IUnitOfWork unitOfWork, IApDungQuyCheHocVuRepository apDungQuyCheHocVuRepository) 
            : base(unitOfWork, apDungQuyCheHocVuRepository)
        {
        }

        protected override Task UpdateEntityProperties(ApDungQuyCheHocVu existingEntity, ApDungQuyCheHocVu newEntity)
        {
            existingEntity.IdKhoaHoc = newEntity.IdKhoaHoc;
            existingEntity.IdBacDaoTao = newEntity.IdBacDaoTao;
            existingEntity.IdLoaiDaoTao = newEntity.IdLoaiDaoTao;
            existingEntity.IdQuyCheTC = newEntity.IdQuyCheTC;
            existingEntity.IdQuyCheNC = newEntity.IdQuyCheNC;
            existingEntity.ChoPhepNoMon = newEntity.ChoPhepNoMon;
            existingEntity.ChoPhepNoDVHT = newEntity.ChoPhepNoDVHT;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
} 