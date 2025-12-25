using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhMucKhoanThuNgoaiHocPhiServices
{
    public class DanhMucKhoanThuNgoaiHocPhiService : BaseService<DanhMucKhoanThuNgoaiHocPhi>, IDanhMucKhoanThuNgoaiHocPhiService
    {
        public DanhMucKhoanThuNgoaiHocPhiService(IUnitOfWork unitOfWork, IDanhMucKhoanThuNgoaiHocPhiRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucKhoanThuNgoaiHocPhi existingEntity, DanhMucKhoanThuNgoaiHocPhi newEntity)
        {
            existingEntity.MaKhoanThu = newEntity.MaKhoanThu;
            existingEntity.TenKhoanThu = newEntity.TenKhoanThu;
            existingEntity.SoTien = newEntity.SoTien;
            existingEntity.STT = newEntity.STT;
            existingEntity.LoaiKhoanThu = newEntity.LoaiKhoanThu;
            existingEntity.DonViTinh = newEntity.DonViTinh;
            existingEntity.ThueVAT = newEntity.ThueVAT;
            existingEntity.GomThueVAT = newEntity.GomThueVAT;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }
    }
}
