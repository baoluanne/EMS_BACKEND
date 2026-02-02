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

            bool isMaPhongChanged = existingPhong.MaPhong != entity.MaPhong;

            int newBedCount = entity.SoLuongGiuong ?? 0;

            for (int i = 1; i <= Math.Max(newBedCount, existingPhong.Giuongs.Count); i++)
            {
                var suffix = i.ToString("D2");
                var targetMaGiuong = $"{entity.MaPhong}-{suffix}";

                var bed = existingPhong.Giuongs.FirstOrDefault(g => g.MaGiuong.EndsWith("-" + suffix));

                if (i <= newBedCount)
                {
                    if (bed != null)
                    {
                        bed.IsDeleted = false;
                        bed.MaGiuong = targetMaGiuong;
                    }
                    else
                    {
                        existingPhong.Giuongs.Add(new KtxGiuong
                        {
                            Id = Guid.NewGuid(),
                            PhongKtxId = existingPhong.Id,
                            MaGiuong = targetMaGiuong,
                            TrangThai = KtxGiuongTrangThai.Trong,
                            NgayTao = DateTime.UtcNow,
                            IsDeleted = false
                        });
                    }
                }
                else
                {
                    if (bed != null && !bed.IsDeleted)
                    {
                        if (bed.SinhVienId != null)
                        {
                            return new Result<KtxPhong>(new Exception($"Không thể giảm xuống {newBedCount} giường vì giường {bed.MaGiuong} đang có sinh viên ở."));
                        }
                        bed.IsDeleted = true;
                    }
                }
            }

            if (existingPhong.LoaiPhong != entity.LoaiPhong)
            {
                if (existingPhong.Giuongs.Any(g => !g.IsDeleted && g.SinhVienId != null))
                {
                    return new Result<KtxPhong>(new Exception("Không thể đổi loại phòng khi đang có sinh viên cư trú."));
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