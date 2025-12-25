using EMS.Application.Services.Base;
using EMS.Application.Services.TiepNhanHoSoSvServices.Dtos;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.TiepNhanHoSoSvServices
{
    public interface ITiepNhanHoSoSvService : IBaseService<TiepNhanHoSoSv>
    {
        Task<Result<PaginationResponse<TiepNhanHoSoSv>>> GetListPaginatedAsync(
            PaginationRequest request,
            TiepNhanHoSoSvFilterRequestDto filter);
        Task<Result<string>> UpdateHoSoAsync(
            List<HoSoSVModel> danhSachTiepNhanHoSo
            );
    }
}