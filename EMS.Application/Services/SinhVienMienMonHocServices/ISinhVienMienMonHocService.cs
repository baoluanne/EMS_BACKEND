using EMS.Application.Services.Base;
using EMS.Application.Services.SinhVienMienMonHocServices.Dtos;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Models;
using EMS.Domain.Models.Import;
using LanguageExt.Common;

namespace EMS.Application.Services.SinhVienMienMonHocServices
{
    public interface ISinhVienMienMonHocService : IBaseService<SinhVienMienMonHoc>
    {
        Task<Result<PaginationResponse<SinhVienMienMonHoc>>> GetSinhVienMienMonHocPaginatedAsync(
            PaginationRequest request,
            SinhVienMienMonHocFilter filter);
        Task<BaseResponse<string>> BulkCreateAsync(BulkCreateRequestDto requestDto);
        Task<ImportResultResponse<SinhVienMienMonHocImportDto>> ImportMienMonHocAsync(byte[] fileBytes);
    }
}