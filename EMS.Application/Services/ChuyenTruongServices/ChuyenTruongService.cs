using EMS.Application.Services.Base;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.StudentManagement;

namespace EMS.Application.Services.ChuyenTruongServices
{
    public class ChuyenTruongService : BaseService<ChuyenTruong>, IChuyenTruongService
    {
        public ChuyenTruongService(IUnitOfWork unitOfWork, IChuyenTruongRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(ChuyenTruong existingEntity, ChuyenTruong newEntity)
        {
            // Map all properties from newEntity to existingEntity
            existingEntity.MaHoSo = newEntity.MaHoSo;
            existingEntity.HoTen = newEntity.HoTen;
            existingEntity.NgaySinh = newEntity.NgaySinh;
            existingEntity.GioiTinh = newEntity.GioiTinh;
            existingEntity.IdCoSo = newEntity.IdCoSo;
            existingEntity.IdKhoaHoc = newEntity.IdKhoaHoc;
            existingEntity.IdBacDaoTao = newEntity.IdBacDaoTao;
            existingEntity.IdLoaiDaoTao = newEntity.IdLoaiDaoTao;
            existingEntity.IdNganhHoc = newEntity.IdNganhHoc;
            existingEntity.IdSinhVien = newEntity.IdSinhVien;
            existingEntity.TuTaoMaSinhVien = newEntity.TuTaoMaSinhVien;
            existingEntity.IdChuyenNganh = newEntity.IdChuyenNganh;
            existingEntity.IdLopHoc = newEntity.IdLopHoc;
            
            return Task.CompletedTask;
        }
    }
}