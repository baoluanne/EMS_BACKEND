using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.NhomLoaiHanhViViPhamServices
{
    public class NhomLoaiHanhViViPhamService : BaseService<NhomLoaiHanhViViPham>, INhomLoaiHanhViViPhamService
    {
        public NhomLoaiHanhViViPhamService(IUnitOfWork unitOfWork, INhomLoaiHanhViViPhamRepository nhomLoaiHanhViViPhamRepository) 
            : base(unitOfWork, nhomLoaiHanhViViPhamRepository)
        {
        }

        protected override Task UpdateEntityProperties(NhomLoaiHanhViViPham existingEntity, NhomLoaiHanhViViPham newEntity)
        {
            existingEntity.MaNhomHanhVi = newEntity.MaNhomHanhVi;
            existingEntity.TenNhomHanhVi = newEntity.TenNhomHanhVi;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
} 