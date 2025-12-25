using EMS.Application.Services.Base;
using EMS.Application.Services.SinhVienServices.Dtos;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.SinhVienServices
{
    public interface ISinhVienService : IBaseService<SinhVien>
    {
        Task<ImportHinhSinhVienResponseDto> ImportImagesAsync(ImportHinhSinhVienRequestDto request);

        Task<Result<List<SinhVien>>> GetSinhVienAllAsync();

        Task<Result<PaginationResponse<SinhVien>>> GetSinhVienPaginationAsync(
            PaginationRequest request,
            SinhVienFilter filter);

        Task<Result<PaginationResponse<SinhVien>>> SearchStudentsPaginatedAsync(PaginationRequest request,
            TimKiemSinhVienFilterRequestDto filter);
    }
}