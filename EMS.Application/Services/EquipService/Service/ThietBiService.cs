using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.EquipManagement;

namespace EMS.Application.Services.EquipService.Service
{
    public class ThietBiService : BaseService<TSTBThietBi>, IThietBiService
    {
        public ThietBiService(
            IUnitOfWork unitOfWork,
            IThietBiRepository repository) 
            : base(unitOfWork, repository)
        {
        }
        protected override Task UpdateEntityProperties(TSTBThietBi existingEntity, TSTBThietBi newEntity)
        {
            existingEntity.TenThietBi = newEntity.TenThietBi;
            existingEntity.Model = newEntity.Model;
            existingEntity.SerialNumber = newEntity.SerialNumber;
            existingEntity.ThongSoKyThuat = newEntity.ThongSoKyThuat;
            existingEntity.NamSanXuat = newEntity.NamSanXuat;
            existingEntity.NgayMua = newEntity.NgayMua;
            existingEntity.NgayHetHanBaoHanh = newEntity.NgayHetHanBaoHanh;
            existingEntity.NguyenGia = newEntity.NguyenGia;
            existingEntity.GiaTriKhauHao = newEntity.GiaTriKhauHao;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.HinhAnhUrl = newEntity.HinhAnhUrl;
            return Task.CompletedTask;
        }
    }
}
