using EMS.Application.Services.GiangVienServices.Dtos;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;
using FluentValidation;

namespace EMS.Application.Services.GiangVienServices.Validation
{
    public class GiangVienImportDtoValidator : AbstractValidator<GiangVienImportDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GiangVienImportDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.MaGiangVien)
                .NotEmpty().WithMessage("Mã giảng viên là bắt buộc")
                .MaximumLength(50).WithMessage("Mã giảng viên không được vượt quá 50 ký tự");

            RuleFor(x => x.HoDem)
                .NotEmpty().WithMessage("Họ đệm là bắt buộc")
                .MaximumLength(100).WithMessage("Họ đệm không được vượt quá 100 ký tự");

            RuleFor(x => x.Ten)
                .NotEmpty().WithMessage("Tên là bắt buộc")
                .MaximumLength(50).WithMessage("Tên không được vượt quá 50 ký tự");

            RuleFor(x => x.NgaySinh)
                .LessThan(DateTime.Today)
                .When(x => x.NgaySinh.HasValue)
                .WithMessage("Ngày sinh phải nhỏ hơn ngày hiện tại");

            RuleFor(x => x.SoDienThoai)
                .MaximumLength(20).WithMessage("Số điện thoại không được vượt quá 20 ký tự")
                .Matches(@"^\d{9,11}$")
                .When(x => !string.IsNullOrWhiteSpace(x.SoDienThoai))
                .WithMessage("Số điện thoại không hợp lệ (9-11 chữ số)");

            RuleFor(x => x.DiaChi)
                .MaximumLength(200).WithMessage("Địa chỉ không được vượt quá 200 ký tự");

            RuleFor(x => x.Email)
                .MaximumLength(100).WithMessage("Email không được vượt quá 100 ký tự")
                .EmailAddress()
                .When(x => !string.IsNullOrWhiteSpace(x.Email))
                .WithMessage("Email không hợp lệ");

            RuleFor(x => x.TenVietTat)
                .MaximumLength(20).WithMessage("Tên viết tắt không được vượt quá 20 ký tự");

            RuleFor(x => x.PhuongTien)
                .MaximumLength(100).WithMessage("Phương tiện không được vượt quá 100 ký tự");

            RuleFor(x => x.TenLoaiGiangVien)
                .NotEmpty().WithMessage("Mã loại giảng viên là bắt buộc")
                .MustAsync(async (ma, ct) =>
                {
                    var repo = _unitOfWork.GetRepository<ILoaiGiangVienRepository>();
                    return await repo.GetFirstAsync(l => l.MaLoaiGiangVien.Trim().ToLower() == ma.Trim().ToLower()
                    || l.TenLoaiGiangVien.Trim().ToLower() == ma.Trim().ToLower()) != null;
                })
                .WithMessage(x => $"Loại giảng viên '{x.TenLoaiGiangVien}' không tồn tại trong hệ thống");

            RuleFor(x => x.TenKhoa)
                .NotEmpty().WithMessage("Mã khoa là bắt buộc")
                .MustAsync(async (ma, ct) =>
                {
                    var repo = _unitOfWork.GetRepository<IKhoaRepository>();
                    return await repo.GetFirstAsync(k => k.MaKhoa.Trim().ToLower() == ma.Trim().ToLower() ||
                    k.TenKhoa.Trim().ToLower() == ma.Trim().ToLower()) != null;
                })
                .WithMessage(x => $"Khoa '{x.TenKhoa}' không tồn tại trong hệ thống");

            RuleFor(x => x.TenHocVi)
                .MustAsync(async (ma, ct) =>
                {
                    if (string.IsNullOrWhiteSpace(ma)) return true;
                    var repo = _unitOfWork.GetRepository<IHocViRepository>();
                    return await repo.GetFirstAsync(h => h.MaHocVi.Trim().ToLower() == ma.Trim().ToLower() || h.TenHocVi.Trim().ToLower() == ma.Trim().ToLower()) != null;
                })
                .WithMessage(x => $"Học vị '{x.TenHocVi}' không tồn tại trong hệ thống");

            RuleFor(x => x.TenToBoMon)
                .MustAsync(async (ma, ct) =>
                {
                    if (string.IsNullOrWhiteSpace(ma)) return true;
                    var repo = _unitOfWork.GetRepository<IToBoMonRepository>();
                    return await repo.GetFirstAsync(t => t.MaToBoMon.Trim().ToLower() == ma.Trim().ToLower() || t.TenToBoMon.Trim().ToLower() == ma.Trim().ToLower()) != null;
                })
                .WithMessage(x => $"Tổ bộ môn '{x.TenToBoMon}' không tồn tại trong hệ thống");

            RuleFor(x => x)
                .MustAsync(async (dto, ct) =>
                {
                    var repo = _unitOfWork.GetRepository<IGiangVienRepository>();
                    return await repo.GetFirstAsync(g => g.MaGiangVien.Trim().ToLower() == dto.MaGiangVien.Trim().ToLower()) == null;
                })
                .WithMessage(x => $"Giảng viên với mã '{x.MaGiangVien}' đã tồn tại trong hệ thống");
        }
    }
}

