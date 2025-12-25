using EMS.Application.Services.Base;
using EMS.Application.Services.MonHocBacDaoTaoServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Models.Import;
using LanguageExt.Common;

namespace EMS.Application.Services.MonHocBacDaoTaoServices
{
    public interface IMonHocBacDaoTaoService : IBaseService<MonHocBacDaoTao>
    {
        Task<Result<bool>> AddBatchAsync(AddMonHocBacDaoTaoRequestDto request);
        Task<Result<bool>> UpdateManyAsync(List<MonHocBacDaoTao> request);
        Task<ImportResultResponse<MonHocBacDaoTaoImportDto>> ImportAsync(byte[] fileBytes);
    }
}