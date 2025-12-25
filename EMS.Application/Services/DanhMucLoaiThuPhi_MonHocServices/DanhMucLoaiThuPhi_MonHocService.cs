using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhMucLoaiThuPhi_MonHocServices
{
    public class DanhMucLoaiThuPhi_MonHocService : BaseService<DanhMucLoaiThuPhi_MonHoc>, IDanhMucLoaiThuPhi_MonHocService
    {
        public DanhMucLoaiThuPhi_MonHocService(IUnitOfWork unitOfWork, IDanhMucLoaiThuPhi_MonHocRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucLoaiThuPhi_MonHoc existingEntity, DanhMucLoaiThuPhi_MonHoc newEntity)
        {
            existingEntity.MaLoaiThuPhi = newEntity.MaLoaiThuPhi;
            existingEntity.TenLoaiThuPhi = newEntity.TenLoaiThuPhi;
            existingEntity.STT = newEntity.STT;
            existingEntity.CapSoHoaDonDienTu = newEntity.CapSoHoaDonDienTu;
            existingEntity.CongThucQuyDoi = newEntity.CongThucQuyDoi;
            existingEntity.MaTKNganHang = newEntity.MaTKNganHang;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }
    }
}
