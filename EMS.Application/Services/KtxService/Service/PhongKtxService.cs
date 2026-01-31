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
    public override async Task<Result<KtxPhong>> UpdateAsync(Guid id, KtxPhong entity)
    {
        try
        {
            var existingPhong = await _repository.GetFirstAsync(
                predicate: i => i.Id == id,
                include: i => i.Include(x => x.Giuongs)
            );

            if (existingPhong == null)
                return new Result<KtxPhong>(new NotFoundException("Phòng không tồn tại."));

            if (existingPhong.MaPhong != entity.MaPhong)
            {
                foreach (var bed in existingPhong.Giuongs.Where(g => !g.IsDeleted))
                {
                    var bedIndex = bed.MaGiuong.Split('-').Last();
                    bed.MaGiuong = $"{entity.MaPhong}-{bedIndex}";
                    _giuongRepo.Update(bed);
                }
            }

            int currentBedCount = existingPhong.Giuongs.Count(g => !g.IsDeleted);
            int newBedCount = entity.SoLuongGiuong ?? 0;

            if (newBedCount < currentBedCount)
            {
                int bedsToKill = currentBedCount - newBedCount;

                var eligibleToSoftDelete = existingPhong.Giuongs
                    .Where(g => !g.IsDeleted && g.SinhVienId == null && g.TrangThai == KtxGiuongTrangThai.Trong)
                    .OrderByDescending(g => g.MaGiuong)
                    .Take(bedsToKill)
                    .ToList();

                if (eligibleToSoftDelete.Count < bedsToKill)
                {
                    return new Result<KtxPhong>(new Exception($"Không thể giảm xuống {newBedCount} giường vì hiện có quá nhiều giường đang có sinh viên ở."));
                }

                foreach (var bed in eligibleToSoftDelete)
                {
                    bed.IsDeleted = true;
                    _giuongRepo.Update(bed);
                }
            }
            else if (newBedCount > currentBedCount)
            {
                for (int i = currentBedCount + 1; i <= newBedCount; i++)
                {
                    var maGiuongNew = $"{entity.MaPhong}-{i:D2}";
                    var newBed = new KtxGiuong
                    {
                        Id = Guid.NewGuid(),
                        PhongKtxId = existingPhong.Id,
                        MaGiuong = maGiuongNew,
                        TrangThai = KtxGiuongTrangThai.Trong,
                        NgayTao = DateTime.UtcNow,
                        IsDeleted = false
                    };
                    _giuongRepo.Add(newBed);
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
            _repository.Update(existingPhong);
            await UnitOfWork.CommitAsync();

            return new Result<KtxPhong>(existingPhong);
        }
        catch (Exception ex)
        {
            return new Result<KtxPhong>(ex.InnerException ?? ex);
        }
    }
    public async Task<Result<List<KtxPhong>>> CreateBatchAsync(BatchCreatePhongModel model)
    {
        try
        {
            var tang = await _tangRepo.GetByIdAsync(model.TangKtxId);
            if (tang == null) return new Result<List<KtxPhong>>(new NotFoundException("Tầng không tồn tại."));

            var listPhongMoi = new List<KtxPhong>();

            for (int i = 0; i < model.SoLuongPhong; i++)
            {
                var soThuTu = model.BatDauTuSo + i;
                var maPhongFormatted = $"R{model.SoGiuongMoiPhong}-{model.TienToMaPhong}{soThuTu}";

                var existing = await _repository.GetFirstAsync(p => p.TangKtxId == model.TangKtxId && p.MaPhong == maPhongFormatted);
                if (existing != null) continue;

                var phong = new KtxPhong
                {
                    Id = Guid.NewGuid(),
                    TangKtxId = model.TangKtxId,
                    Tang = tang,
                    MaPhong = maPhongFormatted,
                    SoLuongGiuong = model.SoGiuongMoiPhong,
                    LoaiPhong = model.LoaiPhong,
                    TrangThai = 0,
                    Giuongs = new List<KtxGiuong>(),
                    ChiSoDienNuocs = new List<KtxChiSoDienNuoc>(),
                    YeuCauSuaChuas = new List<KtxYeuCauSuaChua>()
                };

                for (int j = 1; j <= model.SoGiuongMoiPhong; j++)
                {
                    var sttGiuong = j.ToString("D2");
                    var maGiuongFormatted = $"{maPhongFormatted}-{sttGiuong}";

                    phong.Giuongs.Add(new KtxGiuong
                    {
                        Id = Guid.NewGuid(),
                        PhongKtxId = phong.Id,
                        Phong = phong,
                        MaGiuong = maGiuongFormatted,
                        TrangThai = KtxGiuongTrangThai.Trong,
                        CuTruKtxs = new List<KtxCutru>()
                    });
                }
                listPhongMoi.Add(phong);
            }

            if (listPhongMoi.Any())
            {
                foreach (var p in listPhongMoi) _repository.Add(p);
                await UnitOfWork.CommitAsync();
            }

            return new Result<List<KtxPhong>>(listPhongMoi);
        }
        catch (Exception ex)
        {
            return new Result<List<KtxPhong>>(ex.InnerException ?? ex);
        }
    }
    protected override Task UpdateEntityProperties(KtxPhong existingEntity, KtxPhong newEntity)
    {
        existingEntity.TangKtxId = newEntity.TangKtxId;
        existingEntity.MaPhong = newEntity.MaPhong;
        existingEntity.SoLuongGiuong = newEntity.SoLuongGiuong;
        existingEntity.LoaiPhong = newEntity.LoaiPhong;
        return Task.CompletedTask;
    }
}