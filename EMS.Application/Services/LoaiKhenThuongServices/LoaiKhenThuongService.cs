using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LoaiKhenThuongServices
{
    public class LoaiKhenThuongService : BaseService<LoaiKhenThuong>, ILoaiKhenThuongService
    {
        public LoaiKhenThuongService(IUnitOfWork unitOfWork, ILoaiKhenThuongRepository loaiKhenThuongRepository) 
            : base(unitOfWork, loaiKhenThuongRepository)
        {
        }

        protected override Task UpdateEntityProperties(LoaiKhenThuong existingEntity, LoaiKhenThuong newEntity)
        {
            existingEntity.TenLoaiKhenThuong = newEntity.TenLoaiKhenThuong;
            existingEntity.MaLoaiKhenThuong = newEntity.MaLoaiKhenThuong;
            existingEntity.DiemCongToiDa = newEntity.DiemCongToiDa;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IdNhomLoaiKhenThuong = newEntity.IdNhomLoaiKhenThuong;
            return Task.CompletedTask;
        }
    }
} 