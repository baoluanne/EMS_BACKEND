using EMS.Application.Services.Base;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.StudentManagement;

namespace EMS.Application.Services.DanhSachSinhVienDuocInTheServices
{
    public class DanhSachSinhVienDuocInTheService : BaseService<DanhSachSinhVienDuocInThe>, IDanhSachSinhVienDuocInTheService
    {
        public DanhSachSinhVienDuocInTheService(IUnitOfWork unitOfWork, IDanhSachSinhVienDuocInTheRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhSachSinhVienDuocInThe existingEntity, DanhSachSinhVienDuocInThe newEntity)
        {
            existingEntity.IdSinhVien = newEntity.IdSinhVien;
            existingEntity.CoHinhTheSv = newEntity.CoHinhTheSv;
            existingEntity.NgayImportHinhTheSv = newEntity.NgayImportHinhTheSv;
            
            return Task.CompletedTask;
        }
    }
}