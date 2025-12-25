using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.LoaiHanhViViPhamServices
{
    public class LoaiHanhViViPhamService : BaseService<LoaiHanhViViPham>, ILoaiHanhViViPhamService
    {
        public LoaiHanhViViPhamService(IUnitOfWork unitOfWork, ILoaiHanhViViPhamRepository loaiHanhViViPhamRepository) 
            : base(unitOfWork, loaiHanhViViPhamRepository)
        {
        }

        protected override Task UpdateEntityProperties(LoaiHanhViViPham existingEntity, LoaiHanhViViPham newEntity)
        {
            existingEntity.MaLoaiHanhVi = newEntity.MaLoaiHanhVi;
            existingEntity.TenLoaiHanhVi = newEntity.TenLoaiHanhVi;
            existingEntity.STT = newEntity.STT;
            existingEntity.DiemTruToiDa = newEntity.DiemTruToiDa;
            existingEntity.IsDiemTruCaoNhat = newEntity.IsDiemTruCaoNhat;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IdNhomLoaiHanhVi = newEntity.IdNhomLoaiHanhVi;
            return Task.CompletedTask;
        }
    }
} 