using EMS.Application.Services.Base;
using EMS.Application.Services.PhongHocServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Models.Import;

namespace EMS.Application.Services.PhongHocServices
{
    public interface IPhongHocService : IBaseService<PhongHoc>
    {
        Task<ImportResultResponse<PhongHocImportDto>> ImportAsync(byte[] fileBytes);
    }
}