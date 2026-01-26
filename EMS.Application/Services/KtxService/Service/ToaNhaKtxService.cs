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