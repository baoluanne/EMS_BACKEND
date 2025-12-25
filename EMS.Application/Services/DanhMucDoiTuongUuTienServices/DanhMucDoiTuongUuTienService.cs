using EMS.Application.Services.Base;
using EMS.Domain.Entities.Category;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.Category;

namespace EMS.Application.Services.DanhMucDoiTuongUuTienServices
{
    public class DanhMucDoiTuongUuTienService : BaseService<DanhMucDoiTuongUuTien>, IDanhMucDoiTuongUuTienService
    {
        public DanhMucDoiTuongUuTienService(IUnitOfWork unitOfWork, IDanhMucDoiTuongUuTienRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucDoiTuongUuTien existingEntity, DanhMucDoiTuongUuTien newEntity)
        {
            existingEntity.MaDoiTuong = newEntity.MaDoiTuong;
            existingEntity.TenDoiTuong = newEntity.TenDoiTuong;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }
    }
}