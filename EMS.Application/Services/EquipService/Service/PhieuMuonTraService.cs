using EMS.Application.Services.Base;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Enums.EquipmentManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.EquipManagement;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.EquipService.Service
{
    public class PhieuMuonTraService : BaseService<TSTBPhieuMuonTra>, IPhieuMuonTraService
    {
        public PhieuMuonTraService(IUnitOfWork unitOfWork, IPhieuMuonTraRepository repository)
            : base(unitOfWork, repository) { }

        public override async Task<Result<TSTBPhieuMuonTra>> CreateAsync(TSTBPhieuMuonTra entity)
        {
            var strategy = UnitOfWork.GetDbContext().Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await UnitOfWork.BeginTransactionAsync();
                try
                {
                    // 1. Tự động sinh mã phiếu
                    entity.MaPhieu = $"PM-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString()[..4].ToUpper()}";

                    var thietBiRepo = UnitOfWork.GetRepository<IThietBiRepository>();

                    // 2. Duyệt chi tiết để kiểm tra và cập nhật trạng thái thiết bị
                    foreach (var chiTiet in entity.ChiTietPhieuMuons)
                    {
                        var thietBi = await thietBiRepo.GetByIdAsync(chiTiet.ThietBiId);

                        if (thietBi == null)
                            throw new Exception("Thiết bị không tồn tại.");

                        if (thietBi.TrangThai != TrangThaiThietBiEnum.MoiNhap)
                            throw new Exception($"Thiết bị {thietBi.MaThietBi} hiện không sẵn sàng để mượn.");

                        // Cập nhật trạng thái thiết bị
                        thietBi.TrangThai = TrangThaiThietBiEnum.DangSuDung;
                        thietBiRepo.Update(thietBi);
                    }

                    // 3. Gọi hàm Create của Base để lưu Entity PhieuMuonTra vào DB
                    var result = await base.CreateAsync(entity);

                    await transaction.CommitAsync();
                    return result;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new Result<TSTBPhieuMuonTra>(ex);
                }
            });
        }

        protected override Task UpdateEntityProperties(TSTBPhieuMuonTra existingEntity, TSTBPhieuMuonTra newEntity)
        {
            existingEntity.LoaiDoiTuong = newEntity.LoaiDoiTuong;
            existingEntity.SinhVienId = newEntity.SinhVienId;
            existingEntity.GiangVienId = newEntity.GiangVienId;
            existingEntity.NgayMuon = newEntity.NgayMuon;
            existingEntity.NgayTraDuKien = newEntity.NgayTraDuKien;
            existingEntity.LyDoMuon = newEntity.LyDoMuon;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.GhiChu = newEntity.GhiChu;
            return Task.CompletedTask;
        }
    }
}