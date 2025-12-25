using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhMucKhoanThuTuDoServices
{
    public class DanhMucKhoanThuTuDoService : BaseService<DanhMucKhoanThuTuDo>, IDanhMucKhoanThuTuDoService
    {
        public DanhMucKhoanThuTuDoService(IUnitOfWork unitOfWork, IDanhMucKhoanThuTuDoRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucKhoanThuTuDo existingEntity, DanhMucKhoanThuTuDo newEntity)
        {
            existingEntity.MaKhoanThu = newEntity.MaKhoanThu;
            existingEntity.TenKhoanThu = newEntity.TenKhoanThu;
            existingEntity.SoTien = newEntity.SoTien;
            existingEntity.STT = newEntity.STT;
            existingEntity.LoaiKhoanThu = newEntity.LoaiKhoanThu;
            existingEntity.ThueVAT = newEntity.ThueVAT;
            existingEntity.GomThueVAT = newEntity.GomThueVAT;
            existingEntity.IsVisible = newEntity.IsVisible;
            existingEntity.DonViTinh = newEntity.DonViTinh;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }
    }
}
