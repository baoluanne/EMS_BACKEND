using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.QuyChuanDauRaServices
{
    public class QuyChuanDauRaService : BaseService<QuyChuanDauRa>, IQuyChuanDauRaService
    {
        public QuyChuanDauRaService(IUnitOfWork unitOfWork, IQuyChuanDauRaRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(QuyChuanDauRa existingEntity, QuyChuanDauRa newEntity)
        {
            existingEntity.IdCoSoDaoTao = newEntity.IdCoSoDaoTao;
            existingEntity.IdKhoaHoc = newEntity.IdKhoaHoc;
            existingEntity.IdBacDaoTao = newEntity.IdBacDaoTao;
            existingEntity.IdLoaiDaoTao = newEntity.IdLoaiDaoTao;
            existingEntity.IdChungChi = newEntity.IdChungChi;
            existingEntity.IdChuyenNganh = newEntity.IdChuyenNganh;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IsChuanDauRaBoSung = newEntity.IsChuanDauRaBoSung;
            existingEntity.IdLoaiChungChi = newEntity.IdLoaiChungChi;

            return Task.CompletedTask;
        }
    }
} 