using EMS.Application.Services.Base;
using EMS.Application.Services.MonHocServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Models.Import;

namespace EMS.Application.Services.MonHocServices
{
    public interface IMonHocService : IBaseService<MonHoc>
    {
        Task<ImportResultResponse<MonHocImportDto>> ImportAsync(byte[] fileBytes);
    }
}