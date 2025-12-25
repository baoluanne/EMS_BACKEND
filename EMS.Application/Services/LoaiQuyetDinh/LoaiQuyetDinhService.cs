using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LoaiQuyetDinh
{
    public class LoaiQuyetDinhService : BaseService<Domain.Entities.LoaiQuyetDinh>, ILoaiQuyetDinhService
    {
        public LoaiQuyetDinhService(IUnitOfWork unitOfWork, ILoaiQuyetDinhRepository loaiQDRepository) 
            : base(unitOfWork, loaiQDRepository)
        {
        }

        protected override Task UpdateEntityProperties(Domain.Entities.LoaiQuyetDinh existingEntity, Domain.Entities.LoaiQuyetDinh newEntity)
        {
            existingEntity.MaLoaiQD = newEntity.MaLoaiQD;
            existingEntity.TenLoaiQD = newEntity.TenLoaiQD;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.STT = newEntity.STT;

            return Task.CompletedTask;
        }
    }
} 