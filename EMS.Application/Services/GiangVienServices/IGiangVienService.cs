using EMS.Application.Services.Base;
using EMS.Application.Services.GiangVienServices.Dtos;
using EMS.Domain.Entities;
using EMS.Domain.Models.Import;

namespace EMS.Application.Services.GiangVienServices
{
    public interface IGiangVienService : IBaseService<GiangVien>
    {
        Task<ImportResultResponse<GiangVienImportDto>> ImportAsync(byte[] fileBytes);
    }
}