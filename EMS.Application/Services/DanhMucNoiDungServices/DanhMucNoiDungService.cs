using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhMucNoiDungServices
{
    public class DanhMucNoiDungService : BaseService<DanhMucNoiDung>, IDanhMucNoiDungService
    {
        public DanhMucNoiDungService(IUnitOfWork unitOfWork, IDanhMucNoiDungRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucNoiDung existingEntity, DanhMucNoiDung newEntity)
        {
            existingEntity.LoaiNoiDung = newEntity.LoaiNoiDung;
            existingEntity.NoiDung = newEntity.NoiDung;
            existingEntity.IsVisible = newEntity.IsVisible;
            
            return Task.CompletedTask;
        }
    }
}
