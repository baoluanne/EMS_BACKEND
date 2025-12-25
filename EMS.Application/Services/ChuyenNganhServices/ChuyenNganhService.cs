using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.ChuyenNganhServices
{
    public class ChuyenNganhService : BaseService<ChuyenNganh>, IChuyenNganhService
    {
        public ChuyenNganhService(IUnitOfWork unitOfWork, IChuyenNganhRepository chuyenNganhRepository) 
            : base(unitOfWork, chuyenNganhRepository)
        {
        }

        protected override Task UpdateEntityProperties(ChuyenNganh existingEntity, ChuyenNganh newEntity)
        {
            existingEntity.MaChuyenNganh = newEntity.MaChuyenNganh;
            existingEntity.TenChuyenNganh = newEntity.TenChuyenNganh;
            existingEntity.IdNganhHoc = newEntity.IdNganhHoc;
            existingEntity.MaNganhTuQuan = newEntity.MaNganhTuQuan;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.TenTiengAnh = newEntity.TenTiengAnh;
            existingEntity.TenVietTat = newEntity.TenVietTat;
            existingEntity.STT = newEntity.STT;
            existingEntity.IsVisible = newEntity.IsVisible;

            return Task.CompletedTask;
        }
    }
} 