using EMS.Application.DTOs.Financial;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.FinancialModuleManagement;
using EMS.Domain.Models;
using LanguageExt.Common;

namespace EMS.Application.Services.Financial
{
    public interface ICongNoService : IBaseService<CongNoSinhVien>
    {
        Task<Result<Guid>> AddKhoanThuAsync(AddKhoanThuDto dto);

        Task<Result<CongNoDetailDto>> GetDetailByStudentAsync(Guid sinhVienId, Guid namHocHocKyId);
        Task<CongNoCustomPaging> GetDanhSachCongNoCustomAsync(int page, int pageSize, string keyword);
    }
}