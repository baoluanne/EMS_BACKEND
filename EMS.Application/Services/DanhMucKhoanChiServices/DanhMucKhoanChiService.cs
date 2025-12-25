using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhMucKhoanChiServices
{
    public class DanhMucKhoanChiService : BaseService<DanhMucKhoanChi>, IDanhMucKhoanChiService
    {
        public DanhMucKhoanChiService(IUnitOfWork unitOfWork, IDanhMucKhoanChiRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucKhoanChi existingEntity, DanhMucKhoanChi newEntity)
        {
            existingEntity.MaKhoanChi = newEntity.MaKhoanChi;
            existingEntity.TenKhoanChi = newEntity.TenKhoanChi;
            existingEntity.STT = newEntity.STT;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }
    }
}
