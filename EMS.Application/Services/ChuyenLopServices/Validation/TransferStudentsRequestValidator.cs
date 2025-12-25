using EMS.Application.Services.ChuyenLopServices.Dtos;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Enums;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.ClassManagement;
using EMS.Domain.Interfaces.Repositories.StudentManagement;
using FluentValidation;

namespace EMS.Application.Services.ChuyenLopServices.Validation
{
    public class TransferStudentsRequestValidator : AbstractValidator<TransferStudentsRequestDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private LopHoc? _lopHocCu;
        private LopHoc? _lopHocMoi;

        public TransferStudentsRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            var lopHocRepository = _unitOfWork.GetRepository<ILopHocRepository>();
            var sinhvienRepository = _unitOfWork.GetRepository<ISinhVienRepository>();
            RuleFor(x => x.IdLopCu)
                .NotEmpty().WithMessage("Mã lớp học cũ là bắt buộc")
                .NotEqual(x => x.IdLopMoi).WithMessage("Mã lớp học cũ không được trùng Mã lớp học mới")
                .MustAsync(async (id, ct) =>
                {
                    _lopHocCu = await _unitOfWork.GetRepository<ILopHocRepository>().GetByIdAsync(id);
                    return _lopHocCu != null;
                }).WithMessage("Lớp học cũ không tồn tại");
            RuleFor(x => x.IdLopMoi)
                .NotEmpty().WithMessage("Mã lớp học mới là bắt buộc")
                .NotEqual(x => x.IdLopCu).WithMessage("Mã lớp học mới không được trùng Mã lớp học cũ")
                .MustAsync(async (id, ct) =>
                {
                    _lopHocMoi = await _unitOfWork.GetRepository<ILopHocRepository>().GetByIdAsync(id);
                    return _lopHocMoi != null;
                }).WithMessage("Lớp học mới không tồn tại");
            RuleFor(x => x.IdDanhSachSinhVien)
                .NotEmpty().WithMessage("Danh sách sinh viên không được rỗng")
                .MustAsync(async (dto, IdDanhSachSinhVien, ct) =>
                {
                    var oldStudents = await sinhvienRepository.GetListAsync(f => f.IdLopHoc == dto.IdLopCu && dto.IdDanhSachSinhVien.Contains(f.Id));
                    return oldStudents.Count == IdDanhSachSinhVien.Count();
                }).WithMessage("Danh sách sinh viên phải thuộc lớp học cũ")
                .MustAsync(async (dto, IdDanhSachSinhVien, ct) =>
                {
                    var newStudents = await sinhvienRepository.GetListAsync(f => f.IdLopHoc == dto.IdLopMoi && dto.IdDanhSachSinhVien.Contains(f.Id));
                    return !newStudents.Any();
                }).WithMessage("Danh sách sinh viên phải không thuộc lớp học mới");
            RuleForEach(x => x.IdDanhSachSinhVien)
                .NotEmpty().WithMessage("Mã sinh viên không được rỗng");
            RuleFor(x => x.PhanLoaiChuyenLop)
                .IsInEnum().WithMessage("Phân loại chuyển lớp là bắt buộc")
                .Equal(PhanLoaiChuyenLopEnum.ChuyenLopTuDo)
                .When(x => _lopHocCu?.IdNganhHoc != _lopHocMoi?.IdNganhHoc, ApplyConditionTo.CurrentValidator).WithMessage("Lớp cũ và lớp mới không được cùng ngành")
                .Equal(PhanLoaiChuyenLopEnum.ChuyenLopCungNganh)
                .When(x => _lopHocCu?.IdNganhHoc == _lopHocMoi?.IdNganhHoc, ApplyConditionTo.CurrentValidator).WithMessage("Lớp cũ và lớp mới không được khác ngành");
        }
    }
}
