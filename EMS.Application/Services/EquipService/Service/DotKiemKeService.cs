using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Interfaces.Repositories.EquipManagement;
using LanguageExt.Common;
namespace EMS.Application.Services.EquipService.Service
{
    public class DotKiemKeService : BaseService<TSTBDotKiemKe>, IDotKiemKeService
    {
        private readonly IAuditRepository<TSTBThietBi> _thietBiRepository;
        private readonly IAuditRepository<TSTBChiTietKiemKe> _chiTietRepository;
        public DotKiemKeService(
            IUnitOfWork unitOfWork,
            IDotKiemKeRepository repository) : base(unitOfWork, repository)
        {
        }
        protected override Task UpdateEntityProperties(TSTBDotKiemKe existingEntity, TSTBDotKiemKe newEntity)
        {
            existingEntity.TenDotKiemKe = newEntity.TenDotKiemKe;
            existingEntity.NgayBatDau = newEntity.NgayBatDau;
            existingEntity.NgayKetThuc = newEntity.NgayKetThuc;
            existingEntity.DaHoanThanh = newEntity.DaHoanThanh;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
        public async Task<Result<bool>> AddDevicesFromRoomAsync(Guid dotKiemKeId, Guid phongHocId)
        {
            try
            {
                var dotKiemKe = await Repository.GetByIdAsync(dotKiemKeId);
                if (dotKiemKe == null) return new Result<bool>(new Exception("Đợt kiểm kê không tồn tại"));

                var thietBis = await _thietBiRepository.ListAsync(filter: x => x.PhongHocId == phongHocId);
                if (!thietBis.Any()) return new Result<bool>(new Exception("Phòng học không có thiết bị"));

                var chiTietList = thietBis.Select(tb => new TSTBChiTietKiemKe
                {
                    Id = Guid.NewGuid(),
                    DotKiemKeId = dotKiemKeId,
                    ThietBiId = tb.Id,
                    TrangThaiSoSach = (Domain.Enums.EquipmentManagement.TrangThaiThietBiEnum)tb.TrangThai,
                    TrangThaiThucTe = (Domain.Enums.EquipmentManagement.TrangThaiThietBiEnum)tb.TrangThai,
                    KhopDot = true,
                    NgayTao = DateTime.UtcNow,
                    NgayCapNhat = DateTime.UtcNow
                }).ToArray();

                _chiTietRepository.AddRange(chiTietList);
                await UnitOfWork.CommitAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex.InnerException ?? ex);
            }
        }
    }
}
