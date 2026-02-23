using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Enums.EquipmentManagement;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.EquipManagement;
using LanguageExt;
using LanguageExt.Common;
using LanguageExt.Pipes;
using LanguageExt.TypeClasses;
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
                    entity.MaPhieu = $"PM-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString()[..4].ToUpper()}";
                    entity.TrangThai = TrangThaiPhieuMuonEnum.DangMuon;
                    var thietBiRepo = UnitOfWork.GetRepository<IThietBiRepository>();
                    foreach (var chiTiet in entity.ChiTietPhieuMuons)
                    {
                        var thietBi = await thietBiRepo.GetByIdAsync(chiTiet.ThietBiId);
                        if (thietBi == null) throw new Exception("Thiết bị không tồn tại.");
                        if (thietBi.TrangThai != TrangThaiThietBiEnum.MoiNhap)
                            throw new Exception($"Thiết bị {thietBi.MaThietBi} hiện không sẵn sàng.");

                        thietBi.TrangThai = TrangThaiThietBiEnum.DangSuDung;
                        thietBiRepo.Update(thietBi);
                    }
                    await base.CreateAsync(entity);
                    var resultWithData = await Repository.GetFirstAsync(
                        predicate: x => x.Id == entity.Id, 
                        include: query => query
                            .Include(x => x.SinhVien)
                            .Include(x => x.GiangVien)
                            .Include(x => x.ChiTietPhieuMuons)
                                .ThenInclude(ct => ct.ThietBi)
                    );

                    await transaction.CommitAsync();
                    return new Result<TSTBPhieuMuonTra>(resultWithData ?? entity);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new Result<TSTBPhieuMuonTra>(ex);
                }
            });
        }

        public override async Task<Result<TSTBPhieuMuonTra>> UpdateAsync(Guid id, TSTBPhieuMuonTra entity)
        {
            var strategy = UnitOfWork.GetDbContext().Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await UnitOfWork.BeginTransactionAsync();
                try
                {
                    var existingEntity = await Repository.GetFirstAsync(
                        predicate: x => x.Id == id,
                        include: query => query.Include(x => x.ChiTietPhieuMuons)
                    );

                    if (existingEntity == null)
                        return new Result<TSTBPhieuMuonTra>(new NotFoundException($"ID {id} not found."));

                    await UpdateEntityProperties(existingEntity, entity);

                    var thietBiRepo = UnitOfWork.GetRepository<IThietBiRepository>();

                    foreach (var itemMoi in entity.ChiTietPhieuMuons)
                    {
                        var itemCu = existingEntity.ChiTietPhieuMuons.FirstOrDefault(x => x.ThietBiId == itemMoi.ThietBiId);

                        if (itemCu != null)
                        {
                            if (!itemCu.IsDaTra && itemMoi.IsDaTra)
                            {
                                itemCu.IsDaTra = true;
                                itemCu.NgayTraThucTe = DateTime.UtcNow;
                                itemCu.TinhTrangKhiTra = itemMoi.TinhTrangKhiTra ?? "Bình thường";

                                var thietBi = await thietBiRepo.GetByIdAsync(itemMoi.ThietBiId);
                                if (thietBi != null)
                                {
                                    thietBi.TrangThai = TrangThaiThietBiEnum.MoiNhap;
                                    thietBiRepo.Update(thietBi);
                                }
                            }
                            else if (itemCu.IsDaTra && !string.IsNullOrEmpty(itemMoi.TinhTrangKhiTra))
                            {
                                itemCu.TinhTrangKhiTra = itemMoi.TinhTrangKhiTra;
                            }
                        }
                    }

                    existingEntity.TrangThai = existingEntity.ChiTietPhieuMuons.All(x => x.IsDaTra)
                        ? TrangThaiPhieuMuonEnum.DaTra
                        : TrangThaiPhieuMuonEnum.DangMuon;
                    if (existingEntity.TrangThai == TrangThaiPhieuMuonEnum.DaTra)
                        existingEntity.NgayTraThucTe = DateTime.UtcNow;

                    Repository.Update(existingEntity);
                    await UnitOfWork.CommitAsync();
                    await transaction.CommitAsync();

                    return new Result<TSTBPhieuMuonTra>(existingEntity);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new Result<TSTBPhieuMuonTra>(ex.InnerException ?? ex);
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
            existingEntity.GhiChu = newEntity.GhiChu;

            return Task.CompletedTask;
        }
    }
}