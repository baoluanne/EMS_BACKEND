using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhMucNganhDaoTaoServices
{
    public class DanhMucNganhDaoTaoService : BaseService<DanhMucNganhDaoTao>, IDanhMucNganhDaoTaoService
    {
        public DanhMucNganhDaoTaoService(IUnitOfWork unitOfWork, IDanhMucNganhDaoTaoRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucNganhDaoTao existingEntity, DanhMucNganhDaoTao newEntity)
        {
            existingEntity.MaNganh = newEntity.MaNganh;
            existingEntity.TenNganh = newEntity.TenNganh;
            existingEntity.TenTiengAnh = newEntity.TenTiengAnh;
            existingEntity.TenVietTat = newEntity.TenVietTat;
            existingEntity.MaTuyenSinh = newEntity.MaTuyenSinh;
            existingEntity.STT = newEntity.STT;
            existingEntity.IdKhoa = newEntity.IdKhoa;
            existingEntity.KhoiThi = newEntity.KhoiThi;
            existingEntity.KyTuMaSV = newEntity.KyTuMaSV;
            existingEntity.KhoiNganh = newEntity.KhoiNganh;
            existingEntity.IdKhoiNganh = newEntity.IdKhoiNganh;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IsVisible = newEntity.IsVisible;
            
            return Task.CompletedTask;
        }
    }
}
