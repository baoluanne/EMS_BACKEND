using EMS.Application.DTOs.Financial;
using EMS.Application.Services.Base;
using EMS.Domain.Entities.FinancialModuleManagement;
using LanguageExt.Common;
using static EMS.Application.Services.Financial.PhieuThuService;

namespace EMS.Application.Services.Financial
{
    public interface IPhieuThuService : IBaseService<PhieuThuSinhVien>
    {
        Task<Result<Guid>> CreatePaymentAsync(CreatePhieuThuDto dto);
        Task<PhieuThuCustomPaging> GetDanhSachPhieuThuCustomAsync(int page, int pageSize, string keyword);
    }
}