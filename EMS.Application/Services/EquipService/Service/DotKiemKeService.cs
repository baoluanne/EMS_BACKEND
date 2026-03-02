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
    public class DotKiemKeService : BaseService<TSTBDotKiemKe>, IDotKiemKeService
    {
        private readonly IAuditRepository<TSTBThietBi> _thietBiRepository;

        public DotKiemKeService(
            IUnitOfWork unitOfWork,
            IDotKiemKeRepository repository,
            IAuditRepository<TSTBThietBi> thietBiRepository)
            : base(unitOfWork, repository)
        {
            _thietBiRepository = thietBiRepository;
        }

        // Logic cũ...
        private void ApplyAutoNote(TSTBChiTietKiemKe detail)
        {
            if (detail.TrangThaiThucTe != TrangThaiThietBiEnum.DangSuDung)
            {
                string autoNote = "Thiết bị được đưa về phòng thiết bị";
                if (string.IsNullOrEmpty(detail.GhiChu)) detail.GhiChu = autoNote;
                else if (!detail.GhiChu.Contains(autoNote)) detail.GhiChu += $". {autoNote}";
            }
        }

        public override async Task<Result<TSTBDotKiemKe>> CreateAsync(TSTBDotKiemKe entity)
        {
            var strategy = UnitOfWork.GetDbContext().Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await UnitOfWork.BeginTransactionAsync();
                try
                {
                    entity.NgayTao = DateTime.UtcNow;
                    entity.NgayCapNhat = DateTime.UtcNow;

                    if (entity.ChiTietKiemKes != null && entity.ChiTietKiemKes.Any())
                    {
                        foreach (var item in entity.ChiTietKiemKes)
                        {
                            item.Id = Guid.NewGuid();
                            item.NgayTao = DateTime.UtcNow;
                            item.NgayCapNhat = DateTime.UtcNow;
                            item.KhopDot = item.TrangThaiSoSach == item.TrangThaiThucTe;
                            if (entity.DaHoanThanh == true) ApplyAutoNote(item);
                        }
                    }

                    await base.CreateAsync(entity);

                    if (entity.DaHoanThanh == true) await UpdateDeviceStatusAsync(entity.ChiTietKiemKes);

                    var result = await Repository.GetFirstAsync(
                        predicate: x => x.Id == entity.Id,
                        include: q => q.Include(x => x.ChiTietKiemKes).ThenInclude(ct => ct.ThietBi)
                    );

                    await transaction.CommitAsync();
                    return new Result<TSTBDotKiemKe>(result ?? entity);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new Result<TSTBDotKiemKe>(ex);
                }
            });
        }

        public override async Task<Result<TSTBDotKiemKe>> UpdateAsync(Guid id, TSTBDotKiemKe entity)
        {
            var strategy = UnitOfWork.GetDbContext().Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await UnitOfWork.BeginTransactionAsync();
                try
                {
                    var existingEntity = await Repository.GetFirstAsync(x => x.Id == id, q => q.Include(x => x.ChiTietKiemKes));
                    if (existingEntity == null) return new Result<TSTBDotKiemKe>(new KeyNotFoundException($"ID {id} not found"));

                    bool isJustCompleted = (existingEntity.DaHoanThanh != true) && (entity.DaHoanThanh == true);
                    await UpdateEntityProperties(existingEntity, entity);
                    existingEntity.NgayCapNhat = DateTime.UtcNow;

                    foreach (var itemMoi in entity.ChiTietKiemKes)
                    {
                        if (entity.DaHoanThanh == true) ApplyAutoNote(itemMoi);
                        var itemCu = existingEntity.ChiTietKiemKes.FirstOrDefault(x => x.ThietBiId == itemMoi.ThietBiId);

                        if (itemCu != null)
                        {
                            itemCu.TrangThaiThucTe = itemMoi.TrangThaiThucTe;
                            itemCu.TrangThaiSoSach = itemMoi.TrangThaiSoSach;
                            itemCu.GhiChu = itemMoi.GhiChu;
                            itemCu.KhopDot = itemMoi.TrangThaiSoSach == itemMoi.TrangThaiThucTe;
                            itemCu.NgayCapNhat = DateTime.UtcNow;
                        }
                        else
                        {
                            itemMoi.DotKiemKeId = existingEntity.Id;
                            itemMoi.KhopDot = itemMoi.TrangThaiSoSach == itemMoi.TrangThaiThucTe;
                            itemMoi.NgayTao = DateTime.UtcNow;
                            itemMoi.NgayCapNhat = DateTime.UtcNow;
                            existingEntity.ChiTietKiemKes.Add(itemMoi);
                        }
                    }

                    Repository.Update(existingEntity);
                    await UnitOfWork.CommitAsync();

                    if (isJustCompleted) await UpdateDeviceStatusAsync(existingEntity.ChiTietKiemKes);

                    await transaction.CommitAsync();
                    return new Result<TSTBDotKiemKe>(existingEntity);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new Result<TSTBDotKiemKe>(ex);
                }
            });
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

        private async Task UpdateDeviceStatusAsync(IEnumerable<TSTBChiTietKiemKe> details)
        {
            var thietBiRepo = UnitOfWork.GetRepository<IThietBiRepository>();
            foreach (var item in details)
            {
                if (item.TrangThaiThucTe != item.TrangThaiSoSach)
                {
                    var thietBi = await thietBiRepo.GetByIdAsync(item.ThietBiId);
                    if (thietBi != null)
                    {
                        thietBi.TrangThai = item.TrangThaiThucTe;
                        thietBi.NgayCapNhat = DateTime.UtcNow;
                        if (thietBi.TrangThai != TrangThaiThietBiEnum.DangSuDung)
                        {
                            thietBi.PhongHocId = null;
                            thietBi.PhongKtxId = null;
                            string autoNote = "Thiết bị được đưa về phòng thiết bị";
                            if (string.IsNullOrEmpty(thietBi.GhiChu)) thietBi.GhiChu = autoNote;
                            else if (!thietBi.GhiChu.Contains(autoNote)) thietBi.GhiChu += $". {autoNote}";
                        }
                        thietBiRepo.Update(thietBi);
                    }
                }
            }
            await UnitOfWork.CommitAsync();
        }

        // --- NEW: Lấy danh sách phòng đang có thiết bị ---
        public async Task<Result<IEnumerable<object>>> GetActivePhongHocsAsync()
        {
            try
            {
                // Truy vấn trực tiếp DB Set để dùng Distinct SQL
                var query = UnitOfWork.GetDbContext().Set<TSTBThietBi>()
                    .Where(x => x.PhongHocId != null && !x.IsDeleted)
                    .Select(x => new { Id = x.PhongHoc!.Id, TenPhong = x.PhongHoc.TenPhong })
                    .Distinct();

                var result = await query.ToListAsync();
                return new Result<IEnumerable<object>>(result);
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<object>>(ex);
            }
        }

        public async Task<Result<IEnumerable<object>>> GetActivePhongKtxsAsync()
        {
            try
            {
                var query = UnitOfWork.GetDbContext().Set<TSTBThietBi>()
                    .Where(x => x.PhongKtxId != null && !x.IsDeleted)
                    .Select(x => new { Id = x.PhongKtx!.Id, TenPhong = x.PhongKtx.MaPhong })
                    .Distinct();

                var result = await query.ToListAsync();
                return new Result<IEnumerable<object>>(result);
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<object>>(ex);
            }
        }
    }
}