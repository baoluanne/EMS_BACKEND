using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhMucCanSuLopServices
{
    public class DanhMucCanSuLopService : BaseService<DanhMucCanSuLop>, IDanhMucCanSuLopService
    {
        public DanhMucCanSuLopService(IUnitOfWork unitOfWork, IDanhMucCanSuLopRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucCanSuLop existingEntity, DanhMucCanSuLop newEntity)
        {
            existingEntity.MaChucVu = newEntity.MaChucVu;
            existingEntity.TenChucVu = newEntity.TenChucVu;
            existingEntity.HoatDongDoan = newEntity.HoatDongDoan;
            existingEntity.IdLoaiChucVu = newEntity.IdLoaiChucVu;
            existingEntity.TenTiengAnh = newEntity.TenTiengAnh;
            existingEntity.DiemCong = newEntity.DiemCong;
            existingEntity.STT = newEntity.STT;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }
    }
}
