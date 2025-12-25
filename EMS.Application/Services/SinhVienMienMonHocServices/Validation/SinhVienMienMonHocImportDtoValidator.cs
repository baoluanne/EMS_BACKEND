using EMS.Application.Services.SinhVienMienMonHocServices.Dtos;
using FluentValidation;

namespace EMS.Application.Services.SinhVienMienMonHocServices.Validation
{
    public class SinhVienMienMonHocImportDtoValidator : AbstractValidator<SinhVienMienMonHocImportDto>
    {
        public SinhVienMienMonHocImportDtoValidator()
        {
            RuleFor(x => x.MaSinhVien)
                .NotEmpty().WithMessage("Mã sinh viên là bắt buộc");

            RuleFor(x => x.MaMonHoc)
                .NotEmpty().WithMessage("Mã môn học là bắt buộc");
        }
    }
}