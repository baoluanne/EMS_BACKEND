using EMS.Application.Services.Base;
using EMS.Application.Services.SinhVienDangKiHocPhanServices.Dtos;
using EMS.Domain.Entities.StudentManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.SinhVienDangKiHocPhanServices
{
    public interface ISinhVienDangKiHocPhanService : IBaseService<SinhVienDangKiHocPhan>
    {
        Task<Result<PaginationResponse<SinhVienDangKiHocPhan>>> GetSinhVienDangKyHocPhanPaginatedAsync(
            PaginationRequest request,
            SinhVienDangKiHocPhanFilterRequestDto filter);
    }
}