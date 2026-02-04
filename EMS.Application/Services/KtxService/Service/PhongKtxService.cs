using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Enums;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Services.KtxService.Service;

public class PhongKtxService : BaseService<KtxPhong>, IPhongKtxService
{
    private readonly IPhongKtxRepository _repository;
    private readonly IGiuongKtxRepository _giuongRepo;
    private readonly ITangRepository _tangRepo;

    public PhongKtxService(IUnitOfWork unitOfWork, IPhongKtxRepository repository, ITangRepository tangRepo, IGiuongKtxRepository giuongRepo)
        : base(unitOfWork, repository)
    {
        _repository = repository;
        _giuongRepo = giuongRepo;
        _tangRepo = tangRepo;
    }

    public override async Task<Result<KtxPhong>> CreateAsync(KtxPhong entity)
    {
        try
        {
            var tang = await _tangRepo.GetByIdAsync(entity.TangKtxId);
            if (tang == null) return new Result<KtxPhong>(new NotFoundException("Tầng không tồn tại."));

            if (!string.IsNullOrEmpty(tang.LoaiTang) && !tang.LoaiTang.ToLower().Contains("hỗn hợp"))
            {
                if (entity.LoaiPhong != tang.LoaiTang)
                {
                    return new Result<KtxPhong>(new Exception($"Tầng này quy định dành cho {tang.LoaiTang}. Không thể tạo phòng loại {entity.LoaiPhong}."));
                }
            }

            var existing = await _repository.GetFirstAsync(p => p.TangKtxId == entity.TangKtxId && p.MaPhong == entity.MaPhong);
            if (existing != null) return new Result<KtxPhong>(new Exception("Mã phòng đã tồn tại trên tầng này."));

            entity.Id = Guid.NewGuid();
            entity.Giuongs = new List<KtxGiuong>();

            int bedCount = entity.SoLuongGiuong ?? 0;
            for (int i = 1; i <= bedCount; i++)
            {
                entity.Giuongs.Add(new KtxGiuong
                {
                    Id = Guid.NewGuid(),
                    PhongKtxId = entity.Id,
                    MaGiuong = $"{entity.MaPhong}-{i:D2}",
                    TrangThai = KtxGiuongTrangThai.Trong,
                    NgayTao = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            tang.SoLuongPhong = (tang.SoLuongPhong ?? 0) + 1;
            _tangRepo.Update(tang);

            Repository.Add(entity);
            await UnitOfWork.CommitAsync();

            return new Result<KtxPhong>(entity);
        }
        catch (Exception ex)
        {
            return new Result<KtxPhong>(ex.InnerException ?? ex);
        }
    }

    public override async Task<Result<KtxPhong>> UpdateAsync(Guid id, KtxPhong entity)
    {
        try
        {
            var existingPhong = await _repository.GetFirstAsync(
                predicate: i => i.Id == id,
                include: i => i.Include(x => x.Giuongs).Include(x => x.Tang)
            );

            if (existingPhong == null)
                return new Result<KtxPhong>(new NotFoundException("Phòng không tồn tại."));

            if (existingPhong.Tang != null && !string.IsNullOrEmpty(existingPhong.Tang.LoaiTang))
            {
                bool isFloorMixed = existingPhong.Tang.LoaiTang.ToLower().Contains("hỗn hợp");
                if (!isFloorMixed && entity.LoaiPhong != existingPhong.Tang.LoaiTang)
                {
                    return new Result<KtxPhong>(new Exception($"Tầng này quy định dành cho {existingPhong.Tang.LoaiTang}. Không thể chuyển phòng sang loại {entity.LoaiPhong}."));
                }
            }

            if (existingPhong.LoaiPhong != entity.LoaiPhong)
            {
                if (existingPhong.Giuongs.Any(g => !g.IsDeleted && g.SinhVienId != null))
                {
                    return new Result<KtxPhong>(new Exception("Không thể đổi loại phòng khi đang có sinh viên cư trú."));
                }
            }

            int newBedCount = entity.SoLuongGiuong ?? 0;
            var activeBeds = existingPhong.Giuongs.Where(g => !g.IsDeleted).ToList();
            int occupiedBedCount = activeBeds.Count(g => g.SinhVienId != null);

            if (newBedCount < occupiedBedCount)
            {
                return new Result<KtxPhong>(new Exception($"Không thể giảm xuống {newBedCount} giường vì hiện có {occupiedBedCount} sinh viên đang cư trú."));
            }

            if (newBedCount < activeBeds.Count)
            {
                var emptyBeds = activeBeds
                    .Where(g => g.SinhVienId == null)
                    .OrderByDescending(g => g.MaGiuong)
                    .ToList();

                int bedsToRemove = activeBeds.Count - newBedCount;
                for (int i = 0; i < Math.Min(bedsToRemove, emptyBeds.Count); i++)
                {
                    emptyBeds[i].IsDeleted = true;
                }
            }
            else if (newBedCount > activeBeds.Count)
            {
                int bedsToAdd = newBedCount - activeBeds.Count;

                var deletedBeds = existingPhong.Giuongs
                    .Where(g => g.IsDeleted)
                    .OrderBy(g => g.MaGiuong)
                    .Take(bedsToAdd)
                    .ToList();

                foreach (var bed in deletedBeds)
                {
                    bed.IsDeleted = false;
                }

                int remainingToAdd = bedsToAdd - deletedBeds.Count;
                if (remainingToAdd > 0)
                {
                    int maxBedNumber = 0;
                    if (existingPhong.Giuongs.Any())
                    {
                        maxBedNumber = existingPhong.Giuongs
                            .Select(g => {
                                var parts = g.MaGiuong.Split('-');
                                return int.TryParse(parts.Last(), out int num) ? num : 0;
                            })
                            .DefaultIfEmpty(0)
                            .Max();
                    }

                    for (int i = 1; i <= remainingToAdd; i++)
                    {
                        var suffix = (maxBedNumber + i).ToString("D2");
                        existingPhong.Giuongs.Add(new KtxGiuong
                        {
                            Id = Guid.NewGuid(),
                            PhongKtxId = existingPhong.Id,
                            MaGiuong = $"{entity.MaPhong}-{suffix}",
                            TrangThai = KtxGiuongTrangThai.Trong,
                            NgayTao = DateTime.UtcNow,
                            IsDeleted = false
                        });
                    }
                }
            }

            foreach (var bed in existingPhong.Giuongs)
            {
                var parts = bed.MaGiuong.Split('-');
                var suffix = parts.Last();
                var newMaGiuong = $"{entity.MaPhong}-{suffix}";
                
                if (bed.MaGiuong != newMaGiuong)
                {
                    bed.MaGiuong = newMaGiuong;
                }
            }

            await UpdateEntityProperties(existingPhong, entity);
            await UnitOfWork.CommitAsync();

            return new Result<KtxPhong>(existingPhong);
        }
        catch (DbUpdateConcurrencyException)
        {
            return new Result<KtxPhong>(new Exception("Dữ liệu đã bị thay đổi hoặc bản ghi không còn tồn tại. Vui lòng làm mới trang."));
        }
        catch (Exception ex)
        {
            return new Result<KtxPhong>(ex.InnerException ?? ex);
        }
    }

    protected override Task UpdateEntityProperties(KtxPhong existingEntity, KtxPhong newEntity)
    {
        existingEntity.TangKtxId = newEntity.TangKtxId;
        existingEntity.MaPhong = newEntity.MaPhong;
        existingEntity.SoLuongGiuong = newEntity.SoLuongGiuong;
        existingEntity.LoaiPhong = newEntity.LoaiPhong;
        existingEntity.TrangThai = newEntity.TrangThai;

        return Task.CompletedTask;
    }
}