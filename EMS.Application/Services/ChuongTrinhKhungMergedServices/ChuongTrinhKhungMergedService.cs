using EMS.Application.Services.Base;
using EMS.Domain.Dtos;
using EMS.Domain.Entities.Views;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.Views;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.ChuongTrinhKhungMergedServices;

public class ChuongTrinhKhungMergedService : BaseService<ChuongTrinhKhungMerged>, IChuongTrinhKhungMergedService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IChuongTrinhKhungMergedRepository _chuongTrinhKhungMergedRepository;

    public ChuongTrinhKhungMergedService(IUnitOfWork unitOfWork, IChuongTrinhKhungMergedRepository chuongTrinhKhungMergedRepository)
        : base(unitOfWork, chuongTrinhKhungMergedRepository)
    {
        _unitOfWork = unitOfWork;
        _chuongTrinhKhungMergedRepository = chuongTrinhKhungMergedRepository;
    }

    public Result<PaginationResponse<ChuongTrinhKhungMergedResponseDto>> GetPaginatedMerged(PaginationRequest req, Domain.Dtos.ChuongTrinhKhungFilter filter)
    {
        return _chuongTrinhKhungMergedRepository.GetPaginatedMerged(req, filter);
    }

    protected override Task UpdateEntityProperties(ChuongTrinhKhungMerged existingEntity, ChuongTrinhKhungMerged newEntity)
    {
        return Task.CompletedTask;
    }
}