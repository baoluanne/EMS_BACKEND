using EMS.Application.Services.Base;
using EMS.Domain.Entities.Category;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using EMS.Domain.Interfaces.Repositories.Category;

namespace EMS.Application.Services.DanhMucQuocTichServices
{
    public class DanhMucQuocTichService : BaseService<DanhMucQuocTich>, IDanhMucQuocTichService
    {
        public DanhMucQuocTichService(IUnitOfWork unitOfWork, IDanhMucQuocTichRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucQuocTich existingEntity, DanhMucQuocTich newEntity)
        {
            existingEntity.MaQuocGia = newEntity.MaQuocGia;
            existingEntity.TenQuocGia = newEntity.TenQuocGia;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }
    }
}