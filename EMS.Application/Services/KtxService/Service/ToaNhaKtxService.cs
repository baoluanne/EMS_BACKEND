using EMS.Application.Services.Base;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.Base;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using LanguageExt.Common;

namespace EMS.Application.Services.KtxService.Service;

public class ToaNhaKtxService : BaseService<KTXToaNha>, IToaNhaKtxService
{
    private readonly IToaNhaKtxRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuditRepository<KtxTang> _tangRepository;
    private readonly IAuditRepository<KtxPhong> _phongRepository;
    private readonly IAuditRepository<KtxGiuong> _giuongRepository;

    public ToaNhaKtxService(
        IUnitOfWork unitOfWork,
        IToaNhaKtxRepository repository,
        IAuditRepository<KtxTang> tangRepository,
        IAuditRepository<KtxPhong> phongRepository,
        IAuditRepository<KtxGiuong> giuongRepository)
        : base(unitOfWork, repository)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _tangRepository = tangRepository;
        _phongRepository = phongRepository;
        _giuongRepository = giuongRepository;
    }

    public override async Task<Result<KTXToaNha>> CreateAsync(KTXToaNha entity)
    {
        try
        {
            int soTang = entity.SoTang ?? 1;

            var createResult = await base.CreateAsync(entity);
            if (!createResult.IsSuccess)
            {
                return createResult;
            }

            var toaNhaId = entity.Id;

            await CreateTangsAndPhongsAsync(toaNhaId, soTang, entity.LoaiToaNha);

            var fullEntity = await _repository.GetStructureAsync(toaNhaId);
            return new Result<KTXToaNha>(fullEntity);
        }
        catch (Exception ex)
        {
            return new Result<KTXToaNha>(ex);
        }
    }

    private async Task CreateTangsAndPhongsAsync(Guid toaNhaId, int soTang, int? loaiToaNha)
    {
        for (int tangIndex = 1; tangIndex <= soTang; tangIndex++)
        {
            var (loaiTang, loaiPhong) = GetLoaiTangAndPhong(tangIndex, loaiToaNha);

            var tang = new KtxTang
            {
                Id = Guid.NewGuid(),
                ToaNhaId = toaNhaId,
                TenTang = $"Tầng {tangIndex}",
                LoaiTang = loaiTang,
                SoLuongPhong = 15,
            };

            _tangRepository.Add(tang);
            await _unitOfWork.CommitAsync();

            var phongs = new List<KtxPhong>();
            for (int phongIndex = 1; phongIndex <= 15; phongIndex++)
            {
                var phong = new KtxPhong
                {
                    Id = Guid.NewGuid(),
                    TangKtxId = tang.Id,
                    MaPhong = $"{tangIndex}{phongIndex:D2}",
                    LoaiPhong = loaiPhong,
                    SoLuongGiuong = 10,
                    TrangThai = 0,
                };

                phongs.Add(phong);
            }

            _phongRepository.AddRange(phongs);
            await _unitOfWork.CommitAsync();

            var giuongs = new List<KtxGiuong>();
            foreach (var phong in phongs)
            {
                for (int giuongIndex = 1; giuongIndex <= 10; giuongIndex++)
                {
                    var giuong = new KtxGiuong
                    {
                        Id = Guid.NewGuid(),
                        PhongKtxId = phong.Id,
                        MaGiuong = $"{phong.MaPhong}-G{giuongIndex}",
                        SinhVienId = null,
                        TrangThai = 0,
                    };

                    giuongs.Add(giuong);
                }
            }

            _giuongRepository.AddRange(giuongs);
            await _unitOfWork.CommitAsync();
        }
    }

    private (string loaiTang, string loaiPhong) GetLoaiTangAndPhong(int tangIndex, int? loaiToaNha)
    {
        return loaiToaNha switch
        {
            0 => ("Nam", "Nam"),
            1 => ("Nữ", "Nữ"),
            2 => GetMixedBuildingLayout(tangIndex),
            _ => ("Hỗn hợp", "Hỗn hợp")
        };
    }

    private (string loaiTang, string loaiPhong) GetMixedBuildingLayout(int tangIndex)
    {
        return tangIndex switch
        {
            1 or 2 => ("Nữ", "Nữ"),
            3 or 4 => ("Nam", "Nam"),
            5 => ("Quốc tế", "Quốc tế"),
            _ => ("Hỗn hợp", "Hỗn hợp")
        };
    }

    public async Task<Result<KTXToaNha>> GetToaNhaStructureAsync(Guid id)
    {
        try
        {
            var entity = await _repository.GetStructureAsync(id);
            if (entity == null)
            {
                return new Result<KTXToaNha>(new Exception("Không tìm thấy tòa nhà"));
            }
            return new Result<KTXToaNha>(entity);
        }
        catch (Exception ex)
        {
            return new Result<KTXToaNha>(ex);
        }
    }

    protected override Task UpdateEntityProperties(KTXToaNha existingEntity, KTXToaNha newEntity)
    {
        existingEntity.TenToaNha = newEntity.TenToaNha;
        existingEntity.LoaiToaNha = newEntity.LoaiToaNha;
        existingEntity.SoTang = newEntity.SoTang;
        existingEntity.GhiChu = newEntity.GhiChu;
        return Task.CompletedTask;
    }
}