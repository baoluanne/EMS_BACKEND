using EMS.Application.Services.Base;
using EMS.Domain.Entities.EquipmentManagement;
using EMS.Domain.Enums.EquipmentManagement;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.EquipManagement;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.EquipService.Service
{
    public class PhieuThanhLyService : BaseService<TSTBPhieuThanhLy>, IPhieuThanhLyService
    {
        public PhieuThanhLyService(IUnitOfWork unitOfWork, IPhieuThanhLyRepository repository)
            : base(unitOfWork, repository) { }

        public override async Task<Result<TSTBPhieuThanhLy>> CreateAsync(TSTBPhieuThanhLy entity)
        {
            var strategy = UnitOfWork.GetDbContext().Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await UnitOfWork.BeginTransactionAsync();
                try
                {
                    var thietBiRepo = UnitOfWork.GetRepository<IThietBiRepository>();

                    if (entity.TongTienThuHoi == 0 && entity.ChiTietThanhLys.Any())
                    {
                        entity.TongTienThuHoi = entity.ChiTietThanhLys.Sum(x => x.GiaBan);
                    }

                    foreach (var chiTiet in entity.ChiTietThanhLys)
                    {
                        var thietBi = await thietBiRepo.GetByIdAsync(chiTiet.ThietBiId);
                        if (thietBi == null) throw new Exception("Thiết bị không tồn tại.");

                        if (thietBi.TrangThai != TrangThaiThietBiEnum.Hong &&
                            thietBi.TrangThai != TrangThaiThietBiEnum.ChoThanhLy)
                        {
                            throw new Exception($"Thiết bị {thietBi.MaThietBi} chưa ở trạng thái Hỏng hoặc Chờ thanh lý.");
                        }

                        chiTiet.GiaTriConLai = thietBi.GiaTriKhauHao ?? 0;

                        thietBi.TrangThai = TrangThaiThietBiEnum.DaThanhLy;
                        thietBiRepo.Update(thietBi);
                    }

                    await base.CreateAsync(entity);

                    var resultWithData = await Repository.GetFirstAsync(
                        predicate: x => x.Id == entity.Id,
                        include: query => query.Include(x => x.ChiTietThanhLys).ThenInclude(ct => ct.ThietBi)
                    );

                    await transaction.CommitAsync();
                    return new Result<TSTBPhieuThanhLy>(resultWithData ?? entity);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new Result<TSTBPhieuThanhLy>(ex);
                }
            });
        }

        public override async Task<Result<TSTBPhieuThanhLy>> UpdateAsync(Guid id, TSTBPhieuThanhLy entity)
        {
            var strategy = UnitOfWork.GetDbContext().Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await UnitOfWork.BeginTransactionAsync();
                try
                {
                    var existingEntity = await Repository.GetFirstAsync(
                        predicate: x => x.Id == id,
                        include: query => query.Include(x => x.ChiTietThanhLys)
                    );

                    if (existingEntity == null)
                        return new Result<TSTBPhieuThanhLy>(new NotFoundException($"ID {id} not found."));

                    await UpdateEntityProperties(existingEntity, entity);

                    foreach (var itemMoi in entity.ChiTietThanhLys)
                    {
                        var itemCu = existingEntity.ChiTietThanhLys.FirstOrDefault(x => x.ThietBiId == itemMoi.ThietBiId);
                        if (itemCu != null)
                        {
                            itemCu.GiaBan = itemMoi.GiaBan;
                            itemCu.GhiChu = itemMoi.GhiChu;
                        }
                    }

                    existingEntity.TongTienThuHoi = existingEntity.ChiTietThanhLys.Sum(x => x.GiaBan);

                    Repository.Update(existingEntity);
                    await UnitOfWork.CommitAsync();
                    await transaction.CommitAsync();

                    return new Result<TSTBPhieuThanhLy>(existingEntity);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new Result<TSTBPhieuThanhLy>(ex);
                }
            });
        }

        protected override Task UpdateEntityProperties(TSTBPhieuThanhLy existingEntity, TSTBPhieuThanhLy newEntity)
        {
            existingEntity.SoQuyetDinh = newEntity.SoQuyetDinh;
            existingEntity.NgayThanhLy = newEntity.NgayThanhLy;
            existingEntity.LyDo = newEntity.LyDo;
            return Task.CompletedTask;
        }
    }
}