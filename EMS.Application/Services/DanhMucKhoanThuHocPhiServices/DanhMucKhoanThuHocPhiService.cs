using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DanhMucKhoanThuHocPhiServices
{
    public class DanhMucKhoanThuHocPhiService : BaseService<DanhMucKhoanThuHocPhi>, IDanhMucKhoanThuHocPhiService
    {
        public DanhMucKhoanThuHocPhiService(IUnitOfWork unitOfWork, IDanhMucKhoanThuHocPhiRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(DanhMucKhoanThuHocPhi existingEntity, DanhMucKhoanThuHocPhi newEntity)
        {
            existingEntity.MaKhoanThu = newEntity.MaKhoanThu;
            existingEntity.TenKhoanThu = newEntity.TenKhoanThu;
            existingEntity.STT = newEntity.STT;
            existingEntity.CapSoHoaDonDienTu = newEntity.CapSoHoaDonDienTu;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }
    }
}
