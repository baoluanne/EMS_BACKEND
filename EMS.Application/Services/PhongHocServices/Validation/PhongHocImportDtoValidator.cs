using EMS.Application.Services.PhongHocServices.Dtos;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using FluentValidation;

public class PhongHocImportDtoValidator : AbstractValidator<PhongHocImportDto>
{
    public PhongHocImportDtoValidator(IUnitOfWork unitOfWork)
    {
        var dayNhaRepo = unitOfWork.GetRepository<IDayNhaRepository>();
        var loaiPhongRepo = unitOfWork.GetRepository<ILoaiPhongRepository>();
        var tcMonHocRepo = unitOfWork.GetRepository<ITinhChatMonHocRepository>();

        RuleFor(x => x.MaPhong)
            .NotEmpty().WithMessage("Mã phòng không được để trống")
            .MaximumLength(50).WithMessage("Mã phòng tối đa 50 ký tự");

        RuleFor(x => x.TenPhong)
            .NotEmpty().WithMessage("Tên phòng không được để trống")
            .MaximumLength(100).WithMessage("Tên phòng tối đa 100 ký tự");

        RuleFor(x => x.GhiChu)
            .MaximumLength(300).WithMessage("Ghi chú tối đa 300 ký tự");

        RuleFor(x => x.TenDayNha)
            .NotEmpty().WithMessage("Tên dãy nhà không được để trống")
            .MustAsync(async (tenDayNha, cancellation) =>
            {
                if (string.IsNullOrWhiteSpace(tenDayNha)) return false;
                var list = await dayNhaRepo.ListAsync();
                return list.Any(x => x.TenDayNha.Trim().Equals(tenDayNha.Trim(), StringComparison.OrdinalIgnoreCase) ||
                                    x.MaDayNha.Trim().Equals(tenDayNha.Trim(), StringComparison.OrdinalIgnoreCase));
            })
            .WithMessage(dto => $"Dãy nhà '{dto.TenDayNha}' không tồn tại trong hệ thống");

        RuleFor(x => x.TenLoaiPhong)
            .NotEmpty().WithMessage("Tên loại phòng không được để trống")
            .MustAsync(async (tenLoaiPhong, cancellation) =>
            {
                if (string.IsNullOrWhiteSpace(tenLoaiPhong)) return false;
                var list = await loaiPhongRepo.ListAsync();
                return list.Any(x => x.TenLoaiPhong.Trim().Equals(tenLoaiPhong.Trim(), StringComparison.OrdinalIgnoreCase) ||
                                    x.MaLoaiPhong.Trim().Equals(tenLoaiPhong.Trim(), StringComparison.OrdinalIgnoreCase));
            })
            .WithMessage(dto => $"Loại phòng '{dto.TenLoaiPhong}' không tồn tại trong hệ thống");

        RuleFor(x => x.TenTCMonHoc)
            .NotEmpty().WithMessage("Tên tính chất môn học không được để trống")
            .MustAsync(async (tenTCMonHoc, cancellation) =>
            {
                if (string.IsNullOrWhiteSpace(tenTCMonHoc)) return false;
                var list = await tcMonHocRepo.ListAsync();
                return list.Any(x => x.TenTinhChatMonHoc.Trim().Equals(tenTCMonHoc.Trim(), StringComparison.OrdinalIgnoreCase) ||
                                    x.MaTinhChatMonHoc.Trim().Equals(tenTCMonHoc.Trim(), StringComparison.OrdinalIgnoreCase));
            })
            .WithMessage(dto => $"Tính chất môn học '{dto.TenTCMonHoc}' không tồn tại trong hệ thống");

        RuleFor(x => x.IsNgungDungMayChieuText)
        .Must(value =>
        {
            if (string.IsNullOrWhiteSpace(value)) return true;
            return value == "Sử dụng" || value == "Ngưng sử dụng";
        })
        .WithMessage("Giá trị cột 'Máy chiếu' chỉ được nhập 'Sử dụng' hoặc 'Ngưng sử dụng'");

    }
}
