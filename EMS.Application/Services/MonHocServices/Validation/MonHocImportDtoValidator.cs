using EMS.Application.Services.MonHocServices.Dtos;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using FluentValidation;

namespace EMS.Application.Services.MonHocServices.Validation
{
    public class MonHocImportDtoValidator : AbstractValidator<MonHocImportDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public MonHocImportDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.MaMonHoc)
                .NotEmpty().WithMessage("Mã môn học là bắt buộc");

            RuleFor(x => x.TenMonHoc)
                .NotEmpty().WithMessage("Tên môn học là bắt buộc");

            RuleFor(x => x.TenLoaiMonHoc)
                .NotEmpty().WithMessage("Tên loại môn học là bắt buộc")
                .MustAsync(async (tenLoai, ct) =>
                {
                    if (string.IsNullOrWhiteSpace(tenLoai)) return false;
                    var repo = _unitOfWork.GetRepository<ILoaiMonHocRepository>();
                    var exists = await repo.GetFirstAsync(l => l.TenLoaiMonHoc.Trim().ToLower() == tenLoai.Trim().ToLower() ||
                                                                l.MaLoaiMonHoc.Trim().ToLower() == tenLoai.Trim().ToLower());
                    return exists != null;
                })
                .WithMessage(x => $"Loại môn học '{x.TenLoaiMonHoc}' không tồn tại trong hệ thống");

            RuleFor(x => x.TenKhoa)
                .NotEmpty().WithMessage("Tên khoa là bắt buộc")
                .MustAsync(async (tenKhoa, ct) =>
                {
                    if (string.IsNullOrWhiteSpace(tenKhoa)) return false;
                    var repo = _unitOfWork.GetRepository<IKhoaRepository>();
                    return await repo.GetFirstAsync(k => k.TenKhoa.Trim().ToLower() == tenKhoa.Trim().ToLower() ||
                                                        k.MaKhoa.Trim().ToLower() == tenKhoa.Trim().ToLower()) != null;
                })
                .WithMessage(x => $"Khoa '{x.TenKhoa}' không tồn tại trong hệ thống");

            RuleFor(x => x)
                .MustAsync(async (dto, ct) =>
                {
                    var repo = _unitOfWork.GetRepository<IMonHocRepository>();
                    return await repo
                        .GetFirstAsync(m => m.MaMonHoc == dto.MaMonHoc && m.TenMonHoc == dto.TenMonHoc) == null;
                })
                .WithMessage(x => $"Môn học với Mã '{x.MaMonHoc}' và Tên '{x.TenMonHoc}' đã tồn tại trong hệ thống");
        }
    }
}
