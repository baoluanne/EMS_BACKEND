using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.KhenThuongServices
{
    public class KhenThuongService : BaseService<KhenThuong>, IKhenThuongService
    {
        public KhenThuongService(IUnitOfWork unitOfWork, IKhenThuongRepository khenThuongRepository) 
            : base(unitOfWork, khenThuongRepository)
        {
        }

        protected override Task UpdateEntityProperties(KhenThuong existingEntity, KhenThuong newEntity)
        {
            existingEntity.MaKhenThuong = newEntity.MaKhenThuong;
            existingEntity.TenKhenThuong = newEntity.TenKhenThuong;
            existingEntity.DiemCong = newEntity.DiemCong;
            existingEntity.DiemCongToiDa = newEntity.DiemCongToiDa;
            existingEntity.NoiDung = newEntity.NoiDung;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IsViPhamNoiTru = newEntity.IsViPhamNoiTru;
            existingEntity.IdLoaiKhenThuong = newEntity.IdLoaiKhenThuong;

            return Task.CompletedTask;
        }
    }
} 