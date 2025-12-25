using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhMucHocBongServices
{
    public class DanhMucHocBongService : BaseService<DanhMucHocBong>, IDanhMucHocBongService
    {
        public DanhMucHocBongService(IUnitOfWork unitOfWork, IDanhMucHocBongRepository danhMucHocBongRepository) 
            : base(unitOfWork, danhMucHocBongRepository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucHocBong existingEntity, DanhMucHocBong newEntity)
        {
            existingEntity.MaDanhMuc = newEntity.MaDanhMuc;
            existingEntity.TenDanhMuc = newEntity.TenDanhMuc;
            existingEntity.STT = newEntity.STT;

            return Task.CompletedTask;
        }
    }
} 