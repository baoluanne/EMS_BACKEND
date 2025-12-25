using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhMucLoaiKhoanThuNgoaiHocPhiServices
{
    public class DanhMucLoaiKhoanThuNgoaiHocPhiService : BaseService<DanhMucLoaiKhoanThuNgoaiHocPhi>, IDanhMucLoaiKhoanThuNgoaiHocPhiService
    {
        public DanhMucLoaiKhoanThuNgoaiHocPhiService(IUnitOfWork unitOfWork, IDanhMucLoaiKhoanThuNgoaiHocPhiRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucLoaiKhoanThuNgoaiHocPhi existingEntity, DanhMucLoaiKhoanThuNgoaiHocPhi newEntity)
        {
            existingEntity.MaLoaiKhoanThu = newEntity.MaLoaiKhoanThu;
            existingEntity.TenLoaiKhoanThu = newEntity.TenLoaiKhoanThu;
            existingEntity.STT = newEntity.STT;
            existingEntity.XuatHoaDonDienTu = newEntity.XuatHoaDonDienTu;
            existingEntity.HinhThucThu = newEntity.HinhThucThu;
            existingEntity.PhanBoDoanThu = newEntity.PhanBoDoanThu;
            existingEntity.MaTKNganHang = newEntity.MaTKNganHang;
            
            return Task.CompletedTask;
        }
    }
}
