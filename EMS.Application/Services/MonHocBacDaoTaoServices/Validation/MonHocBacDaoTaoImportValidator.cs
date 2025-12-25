
using EMS.Application.Services.MonHocBacDaoTaoServices.Dtos;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using FluentValidation;

namespace EMS.Application.Services.MonHocBacDaoTaoServices.Validation
{
    public class MonHocBacDaoTaoImportValidator : AbstractValidator<MonHocBacDaoTaoImportDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public MonHocBacDaoTaoImportValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.MaMonHoc)
                .NotEmpty().WithMessage("Mã môn học là bắt buộc");

            RuleFor(x => x.TenMonHoc)
                .NotEmpty().WithMessage("Tên môn học là bắt buộc");

            RuleFor(x => x)
                .MustAsync(async (dto, ct) =>
                {
                    var repo = _unitOfWork.GetRepository<IMonHocRepository>();
                    var monHoc = await repo.GetFirstAsync(m =>
                        m.MaMonHoc.Trim().ToLower() == dto.MaMonHoc!.Trim().ToLower()
                        && m.TenMonHoc.Trim().ToLower() == dto.TenMonHoc!.Trim().ToLower());

                    return monHoc != null;
                })
                .WithMessage(x => $"Môn học với Mã '{x.MaMonHoc}' và Tên '{x.TenMonHoc}' không tồn tại trong hệ thống");

            RuleFor(x => x.MaBacDaoTao)
                .NotEmpty().WithMessage("Mã bậc đào tạo là bắt buộc")
                .MustAsync(async (maBacDaoTao, ct) =>
                {
                    if (string.IsNullOrWhiteSpace(maBacDaoTao)) return false;
                    var repo = _unitOfWork.GetRepository<IBacDaoTaoRepository>();
                    var bacDaoTao = await repo.GetFirstAsync(b =>
                        b.MaBacDaoTao.Trim().ToLower() == maBacDaoTao.Trim().ToLower() ||
                        b.TenBacDaoTao.Trim().ToLower() == maBacDaoTao.Trim().ToLower());

                    return bacDaoTao != null;
                })
                .WithMessage(x => $"Bậc đào tạo với Mã '{x.MaBacDaoTao}' không tồn tại trong hệ thống");
        }
    }
}

