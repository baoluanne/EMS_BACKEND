using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.NhomLoaiKhenThuongServices
{
    public class NhomLoaiKhenThuongService : BaseService<NhomLoaiKhenThuong>, INhomLoaiKhenThuongService
    {
        public NhomLoaiKhenThuongService(IUnitOfWork unitOfWork, INhomLoaiKhenThuongRepository nhomLoaiKhenThuongRepository) 
            : base(unitOfWork, nhomLoaiKhenThuongRepository)
        {
        }

        protected override Task UpdateEntityProperties(NhomLoaiKhenThuong existingEntity, NhomLoaiKhenThuong newEntity)
        {
            existingEntity.MaNhomKhenThuong = newEntity.MaNhomKhenThuong;
            existingEntity.TenNhomKhenThuong = newEntity.TenNhomKhenThuong;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
} 