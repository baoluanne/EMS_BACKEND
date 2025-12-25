using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.HanhViViPhamServices
{
    public class HanhViViPhamService : BaseService<HanhViViPham>, IHanhViViPhamService
    {
        public HanhViViPhamService(IUnitOfWork unitOfWork, IHanhViViPhamRepository hanhViViPhamRepository) 
            : base(unitOfWork, hanhViViPhamRepository)
        {
        }

        protected override Task UpdateEntityProperties(HanhViViPham existingEntity, HanhViViPham newEntity)
        {
            existingEntity.MaHanhVi = newEntity.MaHanhVi;
            existingEntity.TenHanhVi = newEntity.TenHanhVi;
            existingEntity.DiemTru = newEntity.DiemTru;
            existingEntity.NoiDung = newEntity.NoiDung;
            existingEntity.DiemTruToiDa = newEntity.DiemTruToiDa;
            existingEntity.IsViPhamNoiTru = newEntity.IsViPhamNoiTru;
            existingEntity.IsKhongSuDung = newEntity.IsKhongSuDung;
            existingEntity.MucDo = newEntity.MucDo;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IdLoaiHanhVi = newEntity.IdLoaiHanhVi;
            return Task.CompletedTask;
        }
    }
} 