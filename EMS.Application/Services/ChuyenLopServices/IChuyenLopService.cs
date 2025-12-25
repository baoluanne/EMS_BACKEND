using EMS.Application.Services.Base;
using EMS.Application.Services.ChuyenLopServices.Dtos;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.ChuyenLopServices
{
    public interface IChuyenLopService : IBaseService<ChuyenLop>
    {
        // Add custom service methods if needed
        // Task<ImportResultResponse<ChuyenLopImportDto>> ImportAsync(byte[] fileBytes);
        // Task<List<ChuyenLop>> GetByStudentIdAsync(Guid studentId);
        // Task<List<ChuyenLop>> GetByClassIdAsync(Guid classId);

        Task<List<ChuyenLop>> TransferStudents(TransferStudentsRequestDto request);

        Task<Result<PaginationResponse<HocPhanCuDto>>> GetDanhSachHocPhanCuAsync(Guid idSinhVien);

        Task<Result<PaginationResponse<HocPhanMoiDto>>> GetDanhSachHocPhanMoiAsync(Guid idSinhVien, Guid idLopMoi);

        Task<BaseResponse<string>> ChuyenLopTuDoAsync(ChuyenLopTuDoRequestDto request);
    }
}
