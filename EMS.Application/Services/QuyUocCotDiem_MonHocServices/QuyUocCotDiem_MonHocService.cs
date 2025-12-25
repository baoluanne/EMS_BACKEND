using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.QuyUocCotDiem_MonHocServices
{
    public class QuyUocCotDiem_MonHocService : BaseService<QuyUocCotDiem_MonHoc>, IQuyUocCotDiem_MonHocService
    {
        public QuyUocCotDiem_MonHocService(IUnitOfWork unitOfWork, IQuyUocCotDiem_MonHocRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(QuyUocCotDiem_MonHoc existingEntity, QuyUocCotDiem_MonHoc newEntity)
        {
            existingEntity.IdQuyUocCotDiem_NC = newEntity.IdQuyUocCotDiem_NC;
            existingEntity.IdQuyUocCotDiem_TC = newEntity.IdQuyUocCotDiem_TC;
            existingEntity.IdMonHocBacDaoTao = newEntity.IdMonHocBacDaoTao;
            existingEntity.IdTrangThaiXetQuyUoc = newEntity.IdTrangThaiXetQuyUoc;
            existingEntity.GhiChu = newEntity.GhiChu;

            return Task.CompletedTask;
        }
    }
} 