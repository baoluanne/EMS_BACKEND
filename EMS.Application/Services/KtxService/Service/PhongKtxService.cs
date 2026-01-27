using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Enums;
using EMS.Domain.Exceptions;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService.Service;

public class PhongKtxService : BaseService<KtxPhong>, IPhongKtxService
{
    private readonly IPhongKtxRepository _repository;
    private readonly ITangRepository _tangRepo;

    public PhongKtxService(IUnitOfWork unitOfWork, IPhongKtxRepository repository, ITangRepository tangRepo)
        : base(unitOfWork, repository)
    {
        _repository = repository;
        _tangRepo = tangRepo;
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