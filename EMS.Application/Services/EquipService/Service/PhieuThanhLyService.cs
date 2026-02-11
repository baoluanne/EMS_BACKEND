using System;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Enums.EquipmentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Interfaces.Repositories.EquipManagement;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.EquipService.Service
{
    public class PhieuThanhLyService : BaseService<TSTBPhieuThanhLy>, IPhieuThanhLyService
    {
        private readonly IAuditRepository<TSTBThietBi> _thietBiRepository;

        public PhieuThanhLyService(
            IUnitOfWork unitOfWork,
            IPhieuThanhLyRepository repository,
            IAuditRepository<TSTBThietBi> thietBiRepository)
            : base(unitOfWork, repository)
        {
            _thietBiRepository = thietBiRepository;
        }

        public override async Task<Result<TSTBPhieuThanhLy>> CreateAsync(TSTBPhieuThanhLy entity)
        {
            var strategy = UnitOfWork.GetDbContext().Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await UnitOfWork.BeginTransactionAsync();
                try
                {
                    if (entity.ChiTietThanhLys == null || !entity.ChiTietThanhLys.Any())
                    {
                        return new Result<TSTBPhieuThanhLy>(new Exception("Danh sách thanh lý trống"));
                    }

                    decimal tongTien = 0;

                    foreach (var chiTiet in entity.ChiTietThanhLys)
                    {
                        var thietBi = await _thietBiRepository.GetByIdAsync(chiTiet.ThietBiId);

                        // 1. Kiểm tra tồn tại
                        if (thietBi == null)
                            throw new Exception($"Không tìm thấy thiết bị ID: {chiTiet.ThietBiId}");

                        // 2. LOGIC MỚI: Chỉ cho phép thanh lý thiết bị đang Hỏng (Enum = 4)
                        // Nếu bạn muốn cho phép cả "Chờ thanh lý" (Enum = 5) thì thêm vào điều kiện OR
                        if (thietBi.TrangThai != TrangThaiThietBiEnum.Hong)
                        {
                            throw new Exception($"Thiết bị {thietBi.MaThietBi} (Trạng thái: {thietBi.TrangThai}) không bị hỏng, không thể thanh lý.");
                        }

                        // 3. Xử lý logic giá trị
                        chiTiet.GiaTriConLai = thietBi.GiaTriKhauHao ?? 0;
                        tongTien += chiTiet.GiaBan;

                        // 4. Cập nhật trạng thái sang Đã Thanh Lý (Enum = 6)
                        thietBi.TrangThai = TrangThaiThietBiEnum.DaThanhLy;
                        thietBi.NgayCapNhat = DateTime.UtcNow;
                        _thietBiRepository.Update(thietBi);
                    }

                    // Cập nhật Header
                    entity.TongTienThuHoi = tongTien;

                    if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();
                    entity.NgayTao = DateTime.UtcNow;
                    entity.NgayCapNhat = DateTime.UtcNow;

                    Repository.Add(entity);

                    await UnitOfWork.CommitAsync();
                    await transaction.CommitAsync();

                    return new Result<TSTBPhieuThanhLy>(entity);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new Result<TSTBPhieuThanhLy>(ex.InnerException ?? ex);
                }
            });
        }

        protected override Task UpdateEntityProperties(TSTBPhieuThanhLy existingEntity, TSTBPhieuThanhLy newEntity)
        {
            existingEntity.NgayThanhLy = newEntity.NgayThanhLy;
            existingEntity.LyDo = newEntity.LyDo;
            existingEntity.SoQuyetDinh = newEntity.SoQuyetDinh;
            return Task.CompletedTask;
        }
    }
}